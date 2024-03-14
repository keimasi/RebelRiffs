using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class AlbumRepository : RepositoryBase<Album>, IAlbumRepository
{

    private readonly MusicContext _context;

    public AlbumRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
    
}