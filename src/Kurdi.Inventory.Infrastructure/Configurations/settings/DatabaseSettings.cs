
namespace Kurdi.Inventory.Infrastructure.Configurations.Settings;

public class DatabaseSettings
{
    public const string DatabaseSection = "Database";
    public string PostgresConnectionString { get; set; } = string.Empty;
    public string SqlServerConnectionString { get; set; } = string.Empty;
}

