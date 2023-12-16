
using System.Reflection;
using Kurdi.Inventory.Core;
using Kurdi.Inventory.UseCases;

namespace Kurdi.Inventory.Api.Configurations;

public static class MediatorConfig
{
    private static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(UseCaseRoot).GetTypeInfo().Assembly;
        yield return typeof(CoreRoot).GetTypeInfo().Assembly;
    }

    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(GetAssemblies().ToArray()));
        return services;
    }
}
