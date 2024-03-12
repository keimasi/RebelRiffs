namespace MusicManagement.Application.Contracts.ViewModels.AlbumViewModels;

public class AlbumViewModel
{
    public long Id { get; set; }
    public string? Title { get;  set; }
    public string? Category { get; set; }
    public string? Band { get; set; }
    public string? State { get; set; }
}