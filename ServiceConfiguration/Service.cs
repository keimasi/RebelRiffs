using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicManagement.Application;
using MusicManagement.Application.Contracts.Contracts;
using MusicManagement.Domain.IRepository;
using MusicManagement.Infrastructure.EfCore;
using MusicManagement.Infrastructure.EfCore.Repository;

namespace MusicServiceConfiguration
{
    public class Service
    {
        public static void Define(IServiceCollection services, string connectionString)
        {
            //Configure Application
            services.AddTransient<IBandApplication, BandApplication>();
            services.AddTransient<IAlbumApplication, AlbumApplication>();
            services.AddTransient<IAudioApplication, AudioApplication>();


            //Configure Repository

            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IAlbumCategoryRepository, AlbumCategoryRepository>();
            services.AddTransient<IAlbumPictureRepository, AlbumPictureRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IArtistPictureRepository, ArtistPictureRepository>();
            services.AddTransient<IAudioRepository, AudioRepository>();
            services.AddTransient<IBandRepository, BandRepository>();
            services.AddTransient<IBandCategoryRepository, BandCategoryRepository>();
            services.AddTransient<IBandPictureRepository, BandPictureRepository>();
            services.AddTransient<IInstrumentRepository, InstrumentRepository>();

            services.AddDbContext<MusicContext>(
                e => e.UseSqlServer(
                    "Data Source=.;Initial Catalog=DbTest;PersistSecurityInfo=True;User ID=sa;Password=SqlBrok2005;TrustServerCertificate = true"));
        }
    }
}
