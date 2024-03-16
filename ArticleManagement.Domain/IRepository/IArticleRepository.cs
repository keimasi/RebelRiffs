using ArticleManagement.Domain.Entity;
using Framework.Domain;

namespace ArticleManagement.Domain.IRepository;

public interface IArticleRepository : IRepository<Article>
{
    
}