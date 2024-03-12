using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class BandCategoryRepository : RepositoryBase<BandCategory> , IBandCategoryRepository
{
    private readonly MusicContext _context;

    public BandCategoryRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}