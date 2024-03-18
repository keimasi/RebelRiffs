using ArticleManagement.Domain.Entity;
using ArticleManagement.Domain.IRepository;
using Framework.Infrastructure;

namespace ArticleManagement.Infrastructure.EfCore.Repository;

public class TagRepository : RepositoryBase<Tag>, ITagRepository
{
    private readonly ArticleContext _context;

    public TagRepository(ArticleContext context) : base(context)
    {
        _context = context;
    }

}