using DDStartProjectBackEnd.Common.Helpers.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace DDStartProjectBackEnd.StartupSettings
{
    public static class CommonServicesConfiguration
    {
        public static IServiceCollection ConfigureCommonServices(this IServiceCollection services)
        {
            services.AddScoped<ILogger, Logger>();

            return services;
        }
    }
}
