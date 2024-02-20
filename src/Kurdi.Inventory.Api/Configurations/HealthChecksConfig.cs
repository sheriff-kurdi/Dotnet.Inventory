
using Kurdi.Inventory.Infrastructure.Data;

namespace Kurdi.Inventory.Api.Configurations;

public static class HealthChecksConfig
{
    public static IServiceCollection AddConfiguredHealthChecks(this IServiceCollection services)
    {
        services.AddHealthChecks()
            .AddDbContextCheck<AppDbContext>();
        return services;
    }

}
