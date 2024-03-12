using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class BandRepository : RepositoryBase<Band> , IBandRepository
{
    private readonly MusicContext _context;

    public BandRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}