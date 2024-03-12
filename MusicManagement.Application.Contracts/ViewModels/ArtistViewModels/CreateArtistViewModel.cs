using Microsoft.AspNetCore.Http;
using MusicManagement.Domain.Enums;

namespace MusicManagement.Application.Contracts.ViewModels.ArtistViewModels;

public class CreateArtistViewModel
{
    public string Name { get;  set; }
    public string Slug { get;  set; }
    public Gender Gender { get;  set; }
    public DateTime BirthDate { get;  set; }
    public string Description { get;  set; }
    public long Country { get; set; }
    public IFormFile File { get; set; }
    public long? BandId { get; set; }
    public long? InstrumentId { get; private set; }
}