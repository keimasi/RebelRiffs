using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class BandRepository : RepositoryBase<Band>, IBandRepository
{
    private readonly MusicContext _context;

    public BandRepository(MusicContext context) : base(context)
    {
        _context = context;
    }

    public Dictionary<long, string> Bands()
    {
        return _context.Bands.Select(e => new { e.Id, e.Name }).ToList().ToDictionary(e => e.Id, e => e.Name);
    }
}