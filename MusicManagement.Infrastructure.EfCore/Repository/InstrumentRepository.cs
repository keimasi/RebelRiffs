using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class InstrumentRepository : RepositoryBase<Instrument> , IInstrumentRepository
{
    private readonly MusicContext _context;

    public InstrumentRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}