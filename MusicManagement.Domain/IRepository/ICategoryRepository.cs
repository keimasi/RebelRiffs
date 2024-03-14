using Framework.Domain;
using MusicManagement.Domain.Entity;

namespace MusicManagement.Domain.IRepository;

public interface ICategoryRepository : IRepository<Category>
{
    Dictionary<long, string> Categories();
}