using Framework.Application;
using Framework.Infrastructure;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Application.Contracts.ViewModels.AudioViewModel;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Application;

public class AudioApplication : IAudioApplication
{
    private readonly IAudioRepository _audioRepository;
    private readonly IAlbumRepository _albumRepository;
    private readonly IBandRepository _bandRepository;
    private readonly IFileUpload _fileUpload;

    public AudioApplication(IAudioRepository audioRepository, IFileUpload fileUpload, IAlbumRepository albumRepository, IBandRepository bandRepository)
    {
        _audioRepository = audioRepository;
        _fileUpload = fileUpload;
        _albumRepository = albumRepository;
        _bandRepository = bandRepository;
    }

    public async Task<OperationResult> Add(CreateAudioViewModel? audio)
    {
        if (audio is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _audioRepository.AnyEntityAsync(e => e.Title == audio.Title))
            return new OperationResult().Failed(OperationMessage.Duplicated);

        var albumSlug = await _albumRepository.FindAsync(x => x.Id == audio.AlbumId);
        var bandSlug = (await _bandRepository.FindAsync(x => x.Id == albumSlug.BandId))?.Slug;

        var audioPath = $"Bands/{bandSlug}/{albumSlug?.Slug}/{audio.Title}";
        var audioName = await _fileUpload.Upload(audio.MusicFile, audioPath);
         
        var model = new Audio(audio.Title, audioName, audio.AlbumId);
        var add = _audioRepository.AddEntity(model);
        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _audioRepository.SaveChangesAsync()).Parse(OperationMessage.Add);
    }

    public async Task<EditAudioViewModel> Edit(long id)
    {
        if (!await _audioRepository.AnyEntityAsync(e => e.Id == id))
            return new EditAudioViewModel();

        var find = await _audioRepository.FindAsync<EditAudioViewModel>(e => e.Id == id,
            select => new EditAudioViewModel()
            {
                Id = select.Id,
                Title = select.Title,
                AlbumId = select.AlbumId
            }, null);
        if (find is null)
            return new EditAudioViewModel();
        return find;
    }

    public async Task<OperationResult> Edit(EditAudioViewModel? audio)
    {
        if (audio is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (!await _audioRepository.AnyEntityAsync(e => e.Id == audio.Id))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var find = await _audioRepository.FindAsync(e => e.Id == audio.Id);

        var albumSlug = await _albumRepository.FindAsync(x => x.Id == find.AlbumId);
        var bandSlug = (await _bandRepository.FindAsync(x => x.Id == albumSlug.BandId))?.Slug;

        var audioPath = $"Bands/{bandSlug}/{albumSlug?.Slug}/{audio.Title}";
        var audioName = await _fileUpload.Upload(audio.MusicFile, audioPath);

        find?.Edit(audio.Title, audioName, audio.AlbumId);
        return (await _audioRepository.SaveChangesAsync()).Parse(OperationMessage.Edit);
    }

    public async Task<List<AudioViewModel>> ToList(long id)
    {
        CancellationToken token = new CancellationToken();
        var list = await
            _audioRepository.ToViewsWithInclude<AudioViewModel>
                (e => e.AlbumId == id, e => new AudioViewModel()
                {
                    State = e.State.ToString(),
                    Id = e.Id,
                    Title = e.Title,
                    MusicFile = e.Path
                }, token, a => a.Album, a => a.Album.AlbumCategory);
        return list ?? new List<AudioViewModel>(0);
    }

    public async Task<OperationResult> ChangeState(long id)
    {
        if (!await _audioRepository.AnyEntityAsync(e => e.Id == id))
            return new OperationResult().Failed(OperationMessage.NotFound);
        var find = _audioRepository.Find(e => e.Id == id);
        find?.ChangeStatus();

        return new OperationResult().Succeeded(OperationMessage.Done);
    }
}