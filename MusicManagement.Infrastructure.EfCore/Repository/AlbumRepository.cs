using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
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

    public Dictionary<long, long> AlbumCount()
    {
        return _context.Albums.Include(e=>e.Audios)
            .ToDictionary(e => e.Id, e => (long)e.Audios.Count);
    }
}