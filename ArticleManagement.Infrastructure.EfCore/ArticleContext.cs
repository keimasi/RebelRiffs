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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var mapping = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(mapping);
            base.OnModelCreating(modelBuilder);
        }
    }
}
