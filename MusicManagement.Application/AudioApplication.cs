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

    public AudioApplication(IAudioRepository audioRepository)
    {
        _audioRepository = audioRepository;
    }

    public async Task<OperationResult> Add(CreateAudioViewModel? audio)
    {
        if (audio is null)
            return new OperationResult().Failed(OperationMessage.Null);

        if (await _audioRepository.AnyEntity(e => e.Title == audio.Title))
            return new OperationResult().Failed(OperationMessage.Duplicated);

        var model = new Audio(audio.Title, "", audio.AlbumId);
        var add = _audioRepository.Add(model);
        if (add != DbState.Added)
            return new OperationResult().Failed(OperationMessage.FailedAdd);

        return (await _audioRepository.SaveChanges()).Parse(OperationMessage.Add);
    }

    public async Task<EditAudioViewModel> Edit(long id)
    {
        if (await _audioRepository.AnyEntity(e => e.Id == id))
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

        if (!await _audioRepository.AnyEntity(e => e.Id == audio.Id))
            return new OperationResult().Failed(OperationMessage.NotFound);

        var find = _audioRepository.Find(e => e.Id == audio.Id);

        find?.Edit(audio.Title, "", audio.AlbumId);
        return (await _audioRepository.SaveChanges()).Parse(OperationMessage.Edit);
    }

    public async Task<List<AudioViewModel>> ToList()
    {
        CancellationToken token = new CancellationToken();
        var list = await
            _audioRepository.ToViewsWithInclude<AudioViewModel>
                (null, e => new AudioViewModel()
                {
                    State = e.State.ToString(),
                    Id = e.Id,
                    Title = e.Title,
                    Category = e.Album.AlbumCategory.Title,
                    Album = e.Album.Title
                }, token, a => a.Album, a => a.Album.AlbumCategory);
        return list ?? new List<AudioViewModel>(0);
    }

    public async Task<OperationResult> ChangeState(long id)
    {

        if (!await _audioRepository.AnyEntity(e => e.Id == id))
            return new OperationResult().Failed(OperationMessage.NotFound);
        var find = _audioRepository.Find(e => e.Id == id);
        find?.ChangeStatus();
        
        return new OperationResult().Succeeded(OperationMessage.Done);
    }
}