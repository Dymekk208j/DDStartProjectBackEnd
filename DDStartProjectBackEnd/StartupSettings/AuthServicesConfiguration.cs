using DDStartProjectBackEnd.Auth.Data.Services;
using DDStartProjectBackEnd.Auth.Data.Services.Interfaces;
using DDStartProjectBackEnd.Common.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DDStartProjectBackEnd.StartupSettings
{
    public static class AuthServicesConfiguration
    {
        public static IServiceCollection ConfigureAuthServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDbConnection, DbConnection>();

            return services;
        }
    }
}
