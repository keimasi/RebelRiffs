using Microsoft.AspNetCore.Http;

namespace MusicManagement.Application.Contracts.ViewModels.AudioViewModel;

public class CreateAudioViewModel
{
    public string Title { get; set; }
    public IFormFile MusicFile { get; set; }
    public long AlbumId { get; set; }
}