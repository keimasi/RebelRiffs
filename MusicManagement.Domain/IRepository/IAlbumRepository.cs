using Framework.Domain;
using MusicManagement.Domain.Entity;

namespace MusicManagement.Domain.IRepository;

public interface IAlbumRepository : IRepository<Album>
{
    Dictionary<long,long> AlbumCount();
}