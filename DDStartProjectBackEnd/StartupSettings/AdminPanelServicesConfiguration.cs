using DDStartProjectBackEnd.AdminPanel.Users.Data.Services;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDStartProjectBackEnd.StartupSettings
{
    public static class AdminPanelServicesConfiguration
    {
        public static void CofigureAdminPanelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsersService, UsersService>();
        }
    }
}
