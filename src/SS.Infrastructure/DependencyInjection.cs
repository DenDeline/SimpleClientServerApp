using Microsoft.Extensions.DependencyInjection;
using SS.Infrastructure.Repositories;

namespace SS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<UserRepository>();

            return services;
        }
    }
}
