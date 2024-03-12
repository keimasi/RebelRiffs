using Microsoft.AspNetCore.Http;

namespace MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;

public class CreateAlbumViewModel
{
    public string Title { get;  set; }
    public string Slug { get;  set; }
    public DateTime ReleasedDate { get;  set; }
    public IFormFile File { get; set; }
    public long CategoryId { get; set; }
    public long? BandId { get; set; }
}