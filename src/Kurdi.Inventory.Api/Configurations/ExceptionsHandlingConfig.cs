using Kurdi.Inventory.Api.ExceptionsHandling;

namespace Kurdi.Inventory.Api.Configurations;

public static class ExceptionsHandlingConfig
{
    public static IServiceCollection AddCustomExceptionsHandling(this IServiceCollection services)
    {
        // you can chane the exception handling with orders.
        services.AddExceptionHandler<TimeOutExceptionHandler>();
        services.AddExceptionHandler<DefaultExceptionHandler>();
        return services;
    }
}
