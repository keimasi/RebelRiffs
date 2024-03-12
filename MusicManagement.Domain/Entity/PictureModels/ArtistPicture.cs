using Framework.Domain;

namespace MusicManagement.Domain.Entity.PictureModels;

public class ArtistPicture : PictureBase
{
    public Artist Artist { get; private set; }
    public long ArtistId { get; private set; }

    public ArtistPicture(string? path, /*SeoPicture seoPicture,*/ long artistId) : base(path)
    {
        ArtistId = artistId;
    }

    protected ArtistPicture() 
    {
        
    }
}