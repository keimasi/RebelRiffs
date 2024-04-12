using ArticleManagement.Application;
using ArticleManagement.Application.Contracts.Contracts;
using ArticleManagement.Domain.IRepository;
using ArticleManagement.Infrastructure.EfCore;
using ArticleManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ArticleManagement.Infrastructure.Config
{
    public class ArticleManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleTagRepository, ArticleTagRepository>();

            // Configuration Application
            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleTagApplication, ArticleTagApplication>();
            services.AddTransient<ITagApplication, TagApplication>();


            // Configuration Context
            services.AddDbContext<ArticleContext>(e => e.UseSqlServer(connectionString));
        }

    }
}
