using Framework.Domain;

namespace MusicManagement.Domain.Entity.PictureModels;

public class AlbumPicture : PictureBase
{
    public Album Album { get; private set; }
    public long AlbumId { get; private set; }
    public string? Path { get; private set; }

    public AlbumPicture(long albumId, string? path/* SeoPicture seoPicture*/) : base(path)
    {
        AlbumId = albumId;
        Path = path;
        //SeoPicture = seoPicture;
    }

    public AlbumPicture()
    {

    }
}