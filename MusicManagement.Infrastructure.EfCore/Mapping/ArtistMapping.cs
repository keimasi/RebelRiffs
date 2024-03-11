using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Domain.Entity;

namespace MusicManagement.Infrastructure.EfCore.Mapping;

public class ArtistMapping : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("tbArtists");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(30).IsRequired(true);
        builder.Property(e => e.Slug).HasMaxLength(40).IsRequired(true);
        builder.Property(e => e.Description).HasMaxLength(150).IsRequired(false);

        //Relation
        builder.HasOne(e => e.ArtistPicture)
            .WithOne(e => e.Artist).
            HasForeignKey<Artist>(e => e.ArtistPictureId);

        builder.
            HasOne(e => e.Band).
            WithMany(e => e.Artists)
            .HasForeignKey(e => e.BandId);

        builder.
            HasOne(e => e.Instrument).
            WithMany(e => e.Artists)
            .HasForeignKey(e => e.InstrumentId);

    }
}