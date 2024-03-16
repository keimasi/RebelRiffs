using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicManagement.Application;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Domain.IRepository;
using MusicManagement.Infrastructure.EfCore;
using MusicManagement.Infrastructure.EfCore.Repository;

namespace MusicManagement.Infrastructure.Config
{
    public class MusicMangementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            //Configure Application
            services.AddTransient<IBandApplication, BandApplication>();
            services.AddTransient<IAlbumApplication, AlbumApplication>();
            services.AddTransient<IAudioApplication, AudioApplication>();
            services.AddTransient<ICategoryApplication, CategoryApplication>();


            //Configure Repository

            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IAudioRepository, AudioRepository>();
            services.AddTransient<IBandRepository, BandRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IInstrumentRepository, InstrumentRepository>();

            services.AddDbContext<MusicContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
