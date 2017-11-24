using UserManager.Service;
using Microsoft.Extensions.DependencyInjection;
using ZenScrumCore.Services;
using MongoDB.Driver;
using DataRepository;
using Microsoft.AspNetCore.Http;

namespace ZenScrumWebApi
{
    public class StartupDependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IZenScrumService, ZenScrumService>();

            services.AddSingleton<IUserManagerService, UserManagerService>();

            // MongoDB settings
            services.AddSingleton<IMongoClient, MongoClient>(client => new MongoClient("mongodb://192.168.99.100:32798/?3t.connectTimeout=10000&3t.uriVersion=2&3t.connectionMode=direct&3t.connection.name=MongoDB-Docker&readPreference=primary&3t.socketTimeout=0"));
            services.AddSingleton<IDataRepository, MongoDataRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}