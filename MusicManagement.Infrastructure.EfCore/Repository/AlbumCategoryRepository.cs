using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class AlbumCategoryRepository : RepositoryBase<AlbumCategory>, IAlbumCategoryRepository
{

    private readonly MusicContext _context;

    public AlbumCategoryRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}