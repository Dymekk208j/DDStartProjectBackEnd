using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DDStartProjectBackEnd.StartupSettings
{
    public static class AdminPanelRepositoriesConfiguration
    {
        public static void CofigureAdminPanelRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
