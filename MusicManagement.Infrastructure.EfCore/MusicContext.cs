using Microsoft.EntityFrameworkCore;
using MusicManagement.Domain.Entity;
using MusicManagement.Infrastructure.EfCore.Mapping;

namespace MusicManagement.Infrastructure.EfCore;

public class MusicContext : DbContext
{
    public MusicContext(DbContextOptions<MusicContext> context) : base(context) { }

    public DbSet<Band> Bands { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Audio> Audios { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<AlbumCategory> Categories { get; set; }
    public DbSet<Instrument> Instruments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(BandMapping).Assembly;
        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        base.OnModelCreating(modelBuilder);
    }

}