namespace MusicManagement.Domain.Entity;

public class BandCategory : Category
{
    public Band Band { get; private set; }
    public long BandId { get; private set; }

    protected BandCategory()
    {

    }
    public BandCategory(long bandId, string title, string slug) : base(title, slug)
    {
        BandId = bandId;
    }
    public void Edit(long bandId)
    {
        BandId = bandId;
    }
}