using Framework.Domain;
using MusicManagement.Domain.Entity;

namespace MusicManagement.Domain.IRepository;

public interface IBandRepository : IRepository<Band>
{
    Dictionary<long,string> Bands();
}