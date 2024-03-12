using Framework.Domain;
using MusicManagement.Domain.Entity.PictureModels;
using MusicManagement.Domain.Enums;

namespace MusicManagement.Domain.Entity;

public class Artist : EntityBase
{
    public string Name { get; private set; }
    public string Slug { get; private set; }
    public Gender Gender { get; private set; }
    public DateTime BirthDate { get; private set; }
    public string Description { get; private set; }
    public State State { get; private set; }
    public long Country { get; private set; }

    //Seo
    //public SeoPage SeoPage { get; private set; }

    //Relation

    //public ArtistPicture ArtistPicture { get; private set; }
    //public long? ArtistPictureId { get; private set; }
    public string ImagePath { get; private set; }
    public long? BandId { get; private set; }
    public Band Band { get; private set; }

    public Instrument Instrument { get; private set; }
    public long? InstrumentId { get; private set; }

    protected Artist(long country)
    {
        Country = country;
    }

    public Artist(string name, string slug, /*SeoPage seoPage,*/ string imagePath,
        long? bandId, long? instrumentId, long country)
    {
        Name = name;
        Slug = slug;
        //SeoPage = seoPage;
        ImagePath = imagePath;
        BandId = bandId;
        InstrumentId = instrumentId;
        Country = country;
        State = State.Active;
    }

    public void Edit(string name, /*SeoPage seoPage,*/ string imagePath,
        long? bandId, long? instrumentId,long country)
    {
        Name = name;
        //SeoPage = seoPage;
        ImagePath = imagePath;
        BandId = bandId;
        InstrumentId = instrumentId;
        Country = country;
    }

    public override void ChangeStatus()
    {
        State = State is State.Active ? State.UnActive : State.Active;
    }
}