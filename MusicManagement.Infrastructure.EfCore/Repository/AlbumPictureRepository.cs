using Framework.Infrastructure;
using MusicManagement.Domain.Entity.PictureModels;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class AlbumPictureRepository : RepositoryBase<AlbumPicture>, IAlbumPictureRepository
{

    private readonly MusicContext _context;

    public AlbumPictureRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}