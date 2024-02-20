using Kurdi.Inventory.Core;
using Kurdi.Inventory.Core.Contracts.Services;
using Kurdi.Inventory.Core.Services;
using Kurdi.Inventory.Services;

namespace Kurdi.Inventory.Api.Configurations;

public static class DomainServicesConfig
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IReceivingService, ReceivingService>();
        services.AddScoped<ProductsService>();
        services.AddScoped<SalesOrdersService>();
        return services;
    }
}
