using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories;
using DDStartProjectBackEnd.AdminPanel.Users.Data.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DDStartProjectBackEnd.StartupSettings
{
    public static class AdminPanelRepositoriesConfiguration
    {
        public static void ConfigureAdminPanelRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
        }
    }
}
