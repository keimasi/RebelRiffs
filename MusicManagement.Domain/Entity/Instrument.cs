using Framework.Domain;

namespace MusicManagement.Domain.Entity;

public class Instrument : EntityBase
{
    public string? Title { get; private set; }
    public ICollection<Artist> Artists { get; set; }

    protected Instrument()
    {
        
    }
    public Instrument(string? title)
    {
        Title = title;
    }

    public void Edit(string? title)
    {
        Title = title;
    }
}