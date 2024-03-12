using Framework.Infrastructure;
using MusicManagement.Domain.Entity.PictureModels;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class BandPictureRepository : RepositoryBase<BandPicture> , IBandPictureRepository
{
    private readonly MusicContext _context;

    public BandPictureRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}