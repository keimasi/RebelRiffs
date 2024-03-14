using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicManagement.Domain.Entity;
using MusicManagement.Domain.IRepository;

namespace MusicManagement.Infrastructure.EfCore.Repository;

public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
{
    private readonly MusicContext _context;

    public CategoryRepository(MusicContext context) : base(context)
    {
        _context = context;
    }

    public Dictionary<long, string> Categories()
    {
        return _context.Categories.Select(e => new { e.Id, e.Title }).
            ToList().ToDictionary(e => e.Id, e => e.Title);
    }
}