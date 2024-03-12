namespace MusicManagement.Application.Contracts.ViewModels.BandViewModels;

public class BandViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public int NumberOfAudio { get; set; }
}