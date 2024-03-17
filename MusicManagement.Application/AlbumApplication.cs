using Framework.Application;
using Framework.Infrastructure;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Application;

public class AlbumApplication : IAlbumApplication
{
    private readonly IFileUpload _fileUpload;
    private readonly IAlbumRepository _albumRepository;
    private readonly IBandRepository _bandRepository;
    public AlbumApplication(IAlbumRepository albumRepository, IFileUpload fileUpload, IBandRepository bandRepository)
    {
        _albumRepository = albumRepository;
        _fileUpload = fileUpload;
        _bandRepository = bandRepository;
    }

    public async Task<OperationResult> Add(CreateAlbumViewModel? album)
    {
        if (album is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _albumRepository.AnyEntityAsync(e => e.Slug.Contains(album.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var bandSlug = (await _bandRepository.FindAsync(x => x.Id == album.BandId))?.Slug;

        var picturePath = $"Bands/{bandSlug}/{album.Slug}";
        var pictureName = _fileUpload.Upload(album.Picture, picturePath);

        var model = new Album(album.Title, album.Slug, album.ReleasedDate, pictureName,
            album.CategoryId, album.BandId);

        var add = _albumRepository.AddEntity(model);

        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _albumRepository.SaveChangesAsync()).Parse(OperationMessage.Add);
    }

    public async Task<EditAlbumViewModel> Edit(long id)
    {
        if (!await _albumRepository.AnyEntityAsync(e => e.Id == id))
            return new EditAlbumViewModel();

        var find = _albumRepository.Find<EditAlbumViewModel>(
            e => e.Id == id,
            vm => new EditAlbumViewModel()
            {
                Id = vm.Id,
                Slug = vm.Slug,
                BandId = vm.BandId,
                Title = vm.Title,
                CategoryId = vm.AlbumCategoryId,
                ReleasedDate = vm.ReleasedDate,
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

        if (await _albumRepository.AnyEntityAsync(e => e.Slug.Contains(album.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var find = await _albumRepository.FindAsync(e => e.Id == album.Id);

        if (find is null)
            return new OperationResult().Failed(OperationMessage.NotFound);

        var picturePath = $"Album/{find.Slug}";
        var pictureName = _fileUpload.Upload(album.Picture, picturePath);

        find.Edit(album.Title, album.ReleasedDate, pictureName,
            album.CategoryId, album.BandId);
        return (await _albumRepository.SaveChangesAsync()).Parse(OperationMessage.Edit);
    }

    public async Task<List<AlbumViewModel>> ToList(long bandId)
    {
        var token = new CancellationToken();
        var list = await _albumRepository.ToViewsWithInclude<AlbumViewModel>(e => e.BandId == bandId,
            e => new AlbumViewModel()
            {
                Title = e.Title,
                State = e.State.ToString(),
                Band = e.Band.Name,
                Category = e.AlbumCategory.Title,
                Id = e.Id,
                Picture = e.ImagePath
            }, token, e => e.Band, e => e.AlbumCategory);
        return list ?? new List<AlbumViewModel>();
    }

    public async Task<OperationResult> ChangeState(long id)
    {
        var find = _albumRepository.Find(e => e.Id == id);
        if (find is null)
            return new OperationResult().Failed(OperationMessage.NotFound);
        find.ChangeStatus();
        return new OperationResult().Succeeded();
    }
}