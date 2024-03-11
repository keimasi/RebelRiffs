using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Domain.Entity;

namespace MusicManagement.Infrastructure.EfCore.Mapping;

public class AlbumMapping : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.ToTable("tbAlbums");
        builder.HasKey(e => e.Id);

        //Relations

        builder.Property(e => e.Title).HasMaxLength(40).IsRequired();
        builder.Property(e => e.Slug).HasMaxLength(40).IsRequired();
        builder.Property(e => e.ReleasedDate).IsRequired(true);

        builder.HasOne(e => e.AlbumPicture).
            WithOne(e => e.Album)
            .HasForeignKey<Album>(e=>e.AlbumPictureId);


        builder.HasOne(e => e.AlbumCategory).
            WithMany(e => e.Albums).
            HasForeignKey(e => e.AlbumCategoryId);


        builder.HasOne(e => e.Band).
            WithMany(e => e.Albums).
            HasForeignKey(e => e.BandId);

        builder.HasMany(many => many.Audios)
            .WithOne(e => e.Album).
            HasForeignKey(e => e.AlbumId);

    }
}