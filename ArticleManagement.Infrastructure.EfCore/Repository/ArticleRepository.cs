using ArticleManagement.Domain.Entity;
using ArticleManagement.Domain.IRepository;
using Framework.Infrastructure;

namespace ArticleManagement.Infrastructure.EfCore.Repository;

public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
{
    private readonly ArticleContext _context;

    public ArticleRepository(ArticleContext context) : base(context)
    {
        _context = context;
    }
}