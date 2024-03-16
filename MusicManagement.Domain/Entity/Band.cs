using Framework.Domain;
using MusicManagement.Domain.Enums;

namespace MusicManagement.Domain.Entity;

public class Band : EntityBase
{
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public State State { get; private set; }

    //Relation
    public ICollection<BandPicture> Pictures { get; private set; }

    public long? BandCategoryId { get; private set; }
    public Category BandCategory { get; private set; }

    public ICollection<Artist> Artists { get; set; }
    public ICollection<Album> Albums { get; private set; }

    public Band(string name, string slug,long? bandCategoryId)
    {
        Slug = slug;
        BandCategoryId = bandCategoryId;
        Name = name;
        State = State.Active;
    }

    protected Band()
    {

    }

    public void Edit(string name, long? categoryId)
    {
        Name = name;
        BandCategoryId = categoryId;
    }
    public override void ChangeStatus()
    {
        State = State is State.Active ? State.UnActive : State.Active;
    }
}