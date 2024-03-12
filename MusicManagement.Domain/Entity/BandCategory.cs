namespace MusicManagement.Domain.Entity;

public class BandCategory : Category
{
    //Relation
    public ICollection<Band> Bands { get; private set; }
}