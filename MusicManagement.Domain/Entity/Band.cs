using Framework.Domain;
using MusicManagement.Domain.Entity.PictureModels;
using MusicManagement.Domain.Enums;

namespace MusicManagement.Domain.Entity;

public class Band : EntityBase
{
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public State State { get; private set; }

    //Seo
    //public SeoPage SeoPage { get; private set; }

    //Relation
    public ICollection<BandPicture> Pictures { get; private set; }

    public long? BandCategoryId { get; private set; }
    public Category BandCategory { get; private set; }

    public ICollection<Artist> Artists { get; set; }
    public ICollection<Album> Albums { get; private set; }


    public Band(string name, string slug/*, SeoPage seoPage*/, long? bandCategoryId)
    {
        Slug = slug;
        //SeoPage = seoPage;
        BandCategoryId = bandCategoryId;
        Name = name;
        State = State.Active;
    }

    protected Band()
    {

    }

    public void Edit(string name/*, SeoPage seoPage*/, long? categoryId)
    {
        State = State.Active;
        //SeoPage = seoPage;
        Name = name;
        BandCategoryId = categoryId;
    }
    public override void ChangeStatus()
    {
        State = State is State.Active ? State.UnActive : State.Active;
    }
}