using Framework.Application;
using MusicManagement.Application.Contracts.ViewModels.ArtistViewModels;

namespace MusicManagement.Application.Contracts.Contracts;

public interface IArtistApplication
{
    Task<OperationResult> Add(CreateArtistViewModel? artist);
    Task<EditArtistViewModel> Edit(string slug);
    Task<OperationResult> Edit(EditArtistViewModel? artist);
    Task<List<ArtistViewModel>> ToList();
    Task<OperationResult> ChangeState(string slug);
}