
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Infrastructure.DataAccess;

namespace Kurdi.Inventory.Api.Configurations;

public static class RepositoriesConfig
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductsRepo, ProductsRepo>();
        services.AddScoped<ICategoriesRepo, CategoriesRepo>();
        services.AddScoped<ISalesOrdersRepo, SalesOrdersRepo>();
        services.AddScoped<ISalesOrderProductsRepo, SalesOrderProductsRepo>();
        return services;
    }

}
