using Framework.Application;
using MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;

namespace MusicManagement.Application.Contracts.Contracts;

public interface IAlbumApplication
{
    Task<OperationResult> Add(CreateAlbumViewModel? album);
    Task<EditAlbumViewModel> Edit(string slug);
    Task<OperationResult> Edit(EditAlbumViewModel? album);
    Task<List<AlbumViewModel>> ToList();
    Task<OperationResult> ChangeState(string slug);
}