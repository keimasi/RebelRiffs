using Framework.Application;
using MusicManagement.Application.Contracts.ViewModels.AudioViewModel;

namespace MusicManagement.Application.Contracts.Contracts;

public interface IAudioApplication
{
    Task<OperationResult> Add(CreateAudioViewModel? audio);
    Task<EditAudioViewModel> Edit(long id);
    Task<OperationResult> Edit(EditAudioViewModel? audio);
    Task<List<AudioViewModel>> ToList();
    Task<OperationResult> ChangeState(long id);
}