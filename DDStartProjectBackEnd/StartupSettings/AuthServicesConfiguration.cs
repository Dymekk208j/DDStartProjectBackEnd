using DDStartProjectBackEnd.Auth.Services;
using DDStartProjectBackEnd.Auth.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDStartProjectBackEnd.StartupSettings
{
    public static class AuthServicesConfiguration
    {
        public static void CofigureAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
