using ArticleManagement.Domain.Entity;
using Framework.Domain;

namespace ArticleManagement.Domain.IRepository;

public interface ITagRepository : IRepository<Tag>
{
    Dictionary<long, string> Tags();
}