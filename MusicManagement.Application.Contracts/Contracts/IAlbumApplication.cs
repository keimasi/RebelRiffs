using Framework.Application;
using MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;

namespace MusicManagement.Application.Contracts.Contracts;

public interface IAlbumApplication
{
    Task<OperationResult> Add(CreateAlbumViewModel? album);
    Task<EditAlbumViewModel> Edit(long id);
    Task<OperationResult> Edit(EditAlbumViewModel? album);
    Task<List<AlbumViewModel>> ToList(long bandId);
    Task<OperationResult> ChangeState(long id);
}