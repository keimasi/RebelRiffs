using Framework.Application;
using Framework.Infrastructure;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Application;

public class AlbumApplication : IAlbumApplication
{
    private readonly IAlbumRepository _albumRepository;
    public AlbumApplication(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }

    public async Task<OperationResult> Add(CreateAlbumViewModel? album)
    {
        if (album is not null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _albumRepository.AnyEntity(e => e.Slug.Contains(album.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var model = new Album(album.Title, album.Slug, album.ReleasedDate, "",
            album.CategoryId,album.BandId);
        var add = _albumRepository.Add(model);

        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _albumRepository.SaveChanges()).Parse(OperationMessage.Add);
    }

    public async Task<EditAlbumViewModel> Edit(string slug)
    {
        if (await _albumRepository.AnyEntity(e => !e.Slug.Contains(slug)))
            return new EditAlbumViewModel();

        var find = _albumRepository.Find<EditAlbumViewModel>(
            e => e.Slug.Contains(slug),
            vm => new EditAlbumViewModel()
            {
                Id = vm.Id,
                Slug = vm.Slug,
                BandId = vm.BandId,
                Title = vm.Title,
                CategoryId = vm.AlbumCategoryId,
                ReleasedDate = vm.ReleasedDate
            },
            null);
        if (find is null)
            return new EditAlbumViewModel();
        return find;
    }

    public async Task<OperationResult> Edit(EditAlbumViewModel? album)
    {
        if (album is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _albumRepository.AnyEntity(e => e.Slug.Contains(album.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var find = await _albumRepository.FindAsync(e => e.Id == album.Id);

        if (find is null)
            return new OperationResult().Failed(OperationMessage.NotFound);

        find.Edit(album.Title, album.ReleasedDate, "",
            album.CategoryId,album.BandId);
        return (await _albumRepository.SaveChanges()).Parse(OperationMessage.Add);
    }

    public async Task<List<AlbumViewModel>> ToList()
    {
        var token = new CancellationToken();
        var list = await _albumRepository.ToViewsWithInclude<AlbumViewModel>(null,
            e => new AlbumViewModel()
        {
            Title = e.Title,
            State = e.State.ToString(),
            Band = e.Band.Name,
            Category = e.AlbumCategory.Title,
            Id = e.Id
        }, token, e => e.Band,e=>e.AlbumCategory);
        return list ?? new List<AlbumViewModel>();
    }

    public async Task<OperationResult> ChangeState(string slug)
    {
        if (await _albumRepository.AnyEntity(e => !e.Slug.Contains(slug)))
            return new OperationResult().Failed(OperationMessage.NotFound);
        var find = _albumRepository.Find(e => e.Slug.Contains(slug));
        if (find is null)
            return new OperationResult().Failed(OperationMessage.NotFound);
        find.ChangeStatus();
        return new OperationResult().Succeeded();
    }
}