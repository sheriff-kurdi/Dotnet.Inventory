using Kurdi.Inventory.Infrastructure.Configurations.Settings;

namespace Kurdi.Inventory.Api.Configurations;

public static class SettingsConfig
{
    public static IServiceCollection AddSettings(this IServiceCollection services)
    {
        services.AddOptions<DatabaseSettings>()
            .BindConfiguration(DatabaseSettings.DatabaseSection)
            .ValidateDataAnnotations()
            .ValidateOnStart();
        return services;
    }
}
