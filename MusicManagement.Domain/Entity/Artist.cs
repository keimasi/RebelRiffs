using Framework.Domain;
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
    public string ImagePath { get; private set; }


    //Relation
    public long? BandId { get; private set; }
    public Band Band { get; private set; }

    public Instrument Instrument { get; private set; }
    public long? InstrumentId { get; private set; }

    protected Artist()
    {

    }

    public Artist(string name, string slug, string imagePath,
        long? bandId, long? instrumentId, long country)
    {
        Name = name;
        Slug = slug;
        ImagePath = imagePath;
        BandId = bandId;
        InstrumentId = instrumentId;
        Country = country;
        State = State.Active;
    }

    public void Edit(string name, string imagePath,
        long? bandId, long? instrumentId,long country)
    {
        Name = name;
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