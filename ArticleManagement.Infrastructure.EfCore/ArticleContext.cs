using ArticleManagement.Domain.Entity;
using ArticleManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagement.Infrastructure.EfCore
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> context) : base(context) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mapping = typeof(ArticleMapping).Assembly;

            modelBuilder.Entity<Article>(de => de.HasMany(e => e.Tags)
                .WithMany(ef => ef.Articles)
                .UsingEntity<ArticleTag>
                (
                configureRight: r => r.HasOne<Tag>(e => e.Tag).WithMany(f => f.ArticleTags).HasForeignKey(f=>f.TagId),
                configureLeft: l => l.HasOne<Article>(e => e.Article).WithMany(s => s.ArticleTags).HasForeignKey(f=>f.ArticleId)
                ));

            modelBuilder.ApplyConfigurationsFromAssembly(mapping);
            base.OnModelCreating(modelBuilder);
        }
    }
}
