using Framework.Application;
using Framework.Infrastructure;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.BandViewModels;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Application;

public class BandApplication : IBandApplication
{

    private readonly IBandRepository _bandRepository;
    private readonly IAlbumRepository _albumRepository;
    public BandApplication(IBandRepository bandRepository, IAlbumRepository albumRepository)
    {
        _bandRepository = bandRepository;
        _albumRepository = albumRepository;
    }

    public async Task<OperationResult> Add(CreateBandViewModel? band)
    {
        if (band is not null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _bandRepository.AnyEntity(e => e.Slug.Contains(band.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var model = new Band(band.Name, band.Slug, band.BandCategoryId);
        var add = _bandRepository.Add(model);

        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _bandRepository.SaveChanges()).Parse(OperationMessage.Add);
    }

    public async Task<EditBandViewModel> Edit(string slug)
    {
        if (await _bandRepository.AnyEntity(e => !e.Slug.Contains(slug)))
            return new EditBandViewModel();

        var find = _bandRepository.Find<EditBandViewModel>(
            e => e.Slug.Contains(slug),
            vm => new EditBandViewModel()
            {
                Id = vm.Id,
                Slug = vm.Slug,
                BandCategoryId = vm.BandCategoryId,
                Name = vm.Name
            },
            null);
        if (find is null)
            return new EditBandViewModel();
        return find;
    }

    public async Task<OperationResult> Edit(EditBandViewModel? band)
    {
        if (band is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _bandRepository.AnyEntity(e => e.Slug.Contains(band.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var find = await _bandRepository.FindAsync(e => e.Id == band.Id);

        if (find is null)
            return new OperationResult().Failed(OperationMessage.NotFound);

        find.Edit(band.Name, band.Slug, band.BandCategoryId);
        return (await _bandRepository.SaveChanges()).Parse(OperationMessage.Add);
    }

    public async Task<List<BandViewModel>> ToList()
    {
        var token = new CancellationToken();
        var list = await _bandRepository.ToViewsWithInclude<BandViewModel>(null, e => new BandViewModel()
        {
            Id = e.Id,
            Name = e.Name,
            Category = e.BandCategory.Title,
        }, token, e => e.BandCategory);
        var albumCount = _albumRepository.AlbumCount();

        list.Join(albumCount, e=>e.Id, a => a.Key,
            (q,w)=> new BandViewModel()
            {
                Id = q.Id,
                Category = q.Category,
                Name = q.Name,
                NumberOfAudio = w.Value
            });

        return list ?? new List<BandViewModel>();
    }

    public async Task<OperationResult> ChangeState(string slug)
    {
        if (await _bandRepository.AnyEntity(e => !e.Slug.Contains(slug)))
            return new OperationResult().Failed(OperationMessage.NotFound);
        var find = _bandRepository.Find(e => e.Slug.Contains(slug));
        if (find is null)
            return new OperationResult().Failed(OperationMessage.NotFound);
        find.ChangeStatus();
        return new OperationResult().Succeeded();
    }
}