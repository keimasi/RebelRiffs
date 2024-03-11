namespace MusicManagement.Domain.Entity;

public class AlbumCategory : Category
{ 
    //Relation
    public ICollection<Album> Albums { get; private set; }
}