using Framework.Domain;
using MusicManagement.Domain.Enums;

namespace MusicManagement.Domain.Entity;

public class Audio : EntityBase
{
    public string Title { get; private set; }
    public string Path { get; private set; }

    public State State { get; private set; }
    //Relation

    public Album Album { get; private set; }
    public long AlbumId { get; private set; }

    protected Audio()
    {
        
    }

    public Audio(string title, string path, long albumId)
    {
        Title = title;
        Path = path;
        AlbumId = albumId;
        State = State.Active;
    }
    public void Edit(string title, string path, long albumId)
    {
        Title = title;
        Path = path;
        AlbumId = albumId;
    }

    public override void ChangeStatus()
    {
        State = State is State.Active ? State.UnActive : State.Active;
    }
}