using Framework.Infrastructure;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class AudioRepository : RepositoryBase<Audio> , IAudioRepository
{
    private readonly MusicContext _context;

    public AudioRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}