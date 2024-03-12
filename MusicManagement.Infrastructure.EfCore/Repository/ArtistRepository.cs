using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class ArtistRepository : RepositoryBase<Artist> , IArtistRepository
{
    private readonly MusicContext _context;

    public ArtistRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}