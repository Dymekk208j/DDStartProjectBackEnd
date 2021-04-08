using DDStartProjectBackEnd.Auth.Data.Services;
using DDStartProjectBackEnd.Auth.Data.Services.Interfaces;
using DDStartProjectBackEnd.Common.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDStartProjectBackEnd.StartupSettings
{
    public static class AuthServicesConfiguration
    {
        public static void CofigureAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDbConnection, DbConnection>();
        }
    }
}
