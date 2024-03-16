using Framework.Domain;

namespace MusicManagement.Domain.Entity;

public class BandPicture : PictureBase
{
    public Band Band { get; private set; }
    public long BandId { get; private set; }

    public BandPicture(long bandId, string? path/*, SeoPicture seoPicture*/) : base(path)
    {
        BandId = bandId;
    }

    protected BandPicture()
    {
        
    }
}