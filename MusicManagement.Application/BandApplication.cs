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
        if (band is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _bandRepository.AnyEntityAsync(e => e.Slug.Contains(band.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);


        var model = new Band(band.Name, band.Slug.Slugify(), band.BandCategoryId);
        var add = _bandRepository.AddEntity(model);

        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _bandRepository.SaveChangesAsync()).Parse(OperationMessage.Add);
    }

    public async Task<EditBandViewModel> Edit(long id)
    {
        if (!await _bandRepository.AnyEntityAsync(e => e.Id == id))
            return new EditBandViewModel();

        var find = _bandRepository.Find<EditBandViewModel>(
            e => e.Id == id,
            vm => new EditBandViewModel()
            {
                Id = vm.Id,
                BandCategoryId = vm.BandCategoryId,
                Name = vm.Name,
                Slug = vm.Slug
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

        var find = await _bandRepository.FindAsync(e => e.Id == band.Id);

        if (find is null)
            return new OperationResult().Failed(OperationMessage.NotFound);

        find.Edit(band.Name, band.BandCategoryId);
        return (await _bandRepository.SaveChangesAsync()).Parse(OperationMessage.Edit);
    }

    public async Task<List<BandViewModel>> ToList()
    {
        var token = new CancellationToken();
        var list = await _bandRepository.ToViewsWithInclude<BandViewModel>(null, e => new BandViewModel()
        {
            Id = e.Id,
            Name = e.Name,
            State = e.State,
            Category = e.BandCategory.Title,
            NumberOfAudio = e.Albums.Count
        }, token, e => e.BandCategory,e=>e.Albums);

        return list ?? new List<BandViewModel>();
    }

    public async Task<OperationResult> ChangeState(long id)
    {
        if (!await _bandRepository.AnyEntityAsync(e => e.Id == id))
            return new OperationResult().Failed(OperationMessage.NotFound);
        var find = _bandRepository.Find(e => e.Id == id);
        find?.ChangeStatus();
        return (await _bandRepository.SaveChangesAsync()).Parse(OperationMessage.Done);
    }

    public Dictionary<long, string> Bands()
    {
        return _bandRepository.Bands();
    }
}