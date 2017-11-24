using UserManager.Service;
using Microsoft.Extensions.DependencyInjection;
using ZenScrumCore.Services;
using MongoDB.Driver;
using DataRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;

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
            services.AddSingleton<IDataRepository, MongoDataRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}