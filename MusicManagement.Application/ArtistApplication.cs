using Framework.Application;
using Framework.Infrastructure;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.ArtistViewModels;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Application;

public class ArtistApplication : IArtistApplication
{

    private readonly IArtistRepository _artistRepository;

    public ArtistApplication(IArtistRepository artistRepository)
    {
        _artistRepository = artistRepository;
    }

    public async Task<OperationResult> Add(CreateArtistViewModel? artist)
    {
        if (artist is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (!await _artistRepository.AnyEntity(e => e.Slug.Contains(artist.Slug)))
            return new OperationResult().Failed(OperationMessage.DuplicatedSlug);

        var model = new Artist(artist.Name, artist.Slug, "", artist.BandId,
            artist.InstrumentId, artist.Country);
        var add = _artistRepository.Add(model);

        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _artistRepository.SaveChanges()).Parse();
    }

    public async Task<EditArtistViewModel> Edit(string slug)
    {
        if (!await _artistRepository.AnyEntity(e => e.Slug.Contains(slug)))
            return new EditArtistViewModel();

        var find = await _artistRepository.FindAsync<EditArtistViewModel>(
            e => e.Slug.Contains(slug),
            select => new EditArtistViewModel()
            {
                BandId = select.BandId,
                Country = select.Country,
                Gender = select.Gender,
                Id = select.Id,
                Name = select.Name,
                Description = select.Description,
                Slug = select.Slug,
                BirthDate = select.BirthDate
            }, null);

        if (find is null)
            return new EditArtistViewModel();

        return find;
    }

    public async Task<OperationResult> Edit(EditArtistViewModel? artist)
    {
        if (artist is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (!await _artistRepository.AnyEntity(e => e.Slug.Contains(artist.Slug)))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var find = await _artistRepository.FindAsync(e => e.Slug.Contains(artist.Slug));

        find?.Edit(artist.Name, "", artist.BandId,
            artist.InstrumentId, artist.Country);
        return new OperationResult().Succeeded(OperationMessage.Edit);
    }

    public async Task<List<ArtistViewModel>> ToList()
    {
        CancellationToken token = new CancellationToken();

        var list = await _artistRepository
            .ToViewsWithInclude(null, e => new ArtistViewModel()
            {
                BandName = e.Band.Name,
                Id = e.Id,
                Name = e.Name,
                Image = e.ImagePath
            }, token, e => e.Band);
        return list ?? new List<ArtistViewModel>(0);
    }

    public async Task<OperationResult> ChangeState(string slug)
    {

        if (!await _artistRepository.AnyEntity(e => e.Slug.Contains(slug)))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var find = await _artistRepository.FindAsync(e => e.Slug.Contains(slug));
        find?.ChangeStatus();
        return new OperationResult().Succeeded(OperationMessage.Done);
    }
}