using UserManager.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ZenScrumWebApi
{
    public class StartupDependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUserManagerService, UserManagerService>();
        }
    }
}