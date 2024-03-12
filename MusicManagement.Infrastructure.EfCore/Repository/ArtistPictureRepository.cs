using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MusicManagement.Domain.Entity.PictureModels;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class ArtistPictureRepository : RepositoryBase<ArtistPicture> , IArtistPictureRepository
{
    private readonly MusicContext _context;

    public ArtistPictureRepository(MusicContext context) : base(context)
    {
        _context = context;
    }
}