using UserManager.Service;
using Microsoft.Extensions.DependencyInjection;
using ZenScrumCore.Services;
using DataRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ZenScrumWebApi
{
    public class StartupDependencyInjection
    {
        internal static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IZenScrumService, ZenScrumService>();

            services.AddSingleton<IUserManagerService, UserManagerService>();

            // MongoDB settings
            services.AddSingleton<DatabaseConfiguration>(conf => new DatabaseConfiguration {
                ConnectionString = configuration["database:connectionString"],
                DatabaseName = configuration["database:databaseName"]

            });

            services.AddSingleton(typeof(IDataRepository<>), typeof(MongoDataRepository<>));

            // used by Url resolver for auto mapping
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}