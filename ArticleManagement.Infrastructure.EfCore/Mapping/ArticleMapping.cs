using ArticleManagement.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleManagement.Infrastructure.EfCore.Mapping;

public class ArticleMapping : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.HasKey(e => e.Id);


        builder.HasMany(e => e.Tags).WithOne(e => e.Article).HasForeignKey(e => e.ArticleId);

    }
}