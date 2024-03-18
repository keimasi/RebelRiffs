using ArticleManagement.Domain.Entity;
using ArticleManagement.Domain.IRepository;
using Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagement.Infrastructure.EfCore.Repository;

public class ArticleTagRepository : RepositoryBase<ArticleTag> , IArticleTagRepository
{
    private readonly ArticleContext _context;

    public ArticleTagRepository(ArticleContext context) : base(context)
    {
        _context = context;
    }
}