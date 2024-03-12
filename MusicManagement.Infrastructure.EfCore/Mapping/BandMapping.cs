using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicManagement.Domain.Entity;

namespace MusicManagement.Infrastructure.EfCore.Mapping;

public class BandMapping : IEntityTypeConfiguration<Band>
{
    public void Configure(EntityTypeBuilder<Band> builder)
    {
        builder.ToTable("tbBands");
        builder.HasKey(e => e.Id);

       
        //Relations


        builder.HasMany(many => many.Pictures)
            .WithOne(one => one.Band)
            .HasForeignKey(e => e.BandId);

        builder.HasOne(e => e.BandCategory)
            .WithMany(e => e.Bands).HasForeignKey(e => e.BandCategoryId);

        builder.HasMany(many => many.Artists).
            WithOne(e => e.Band)
            .HasForeignKey(e => e.BandId);

        builder.HasMany(e => e.Albums).
            WithOne(e => e.Band)
            .HasForeignKey(e => e.BandId);

    }
}