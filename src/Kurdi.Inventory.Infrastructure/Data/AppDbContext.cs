using Microsoft.EntityFrameworkCore;
using Kurdi.Inventory.Core.Entities;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Infrastructure.Configurations.Settings;
using Microsoft.Extensions.Options;
using Kurdi.Inventory.Infrastructure.Configurations.Entities.CategoriesAggregate;
using Kurdi.Inventory.Infrastructure.Configurations.Entities.ProductsAggregate;
using Kurdi.Inventory.Infrastructure.Configurations.Entities;

namespace Kurdi.Inventory.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IOptions<DatabaseSettings> _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<DatabaseSettings> configuration) : base(options)
        {
            _configuration = configuration;
            // _dispatcher = dispatcher;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
             DatabaseSettings databaseSettings = _configuration.Value;

            //options.UseSqlServer(databaseSettings.SqlServerConnectionString);
            options.UseNpgsql(databaseSettings.PostgresConnectionString).UseSnakeCaseNamingConvention();

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LanguagesConfiguration());

            builder.ApplyConfiguration(new CategoriesConfiguration());
            builder.ApplyConfiguration(new CategoriesDetailsConfiguration());

            builder.ApplyConfiguration(new ProductsConfiguration());
            builder.ApplyConfiguration(new ProductsDetailsConfiguration());
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetails> CategoriesDetails { get; set; }
        //public DbSet<SalesOrder> SalesOrders { get; set; }
        //public DbSet<SalesOrderProduct> SalesOrderProducts { get; set; }
        //public DbSet<SalesOrderStatus> SalesOrderStatuses { get; set; }


    }
}
/***
     dotnet ef migrations add InitialMigration-naming --context AppDbContext -p ../Kurdi.Inventory.Infrastructure/Kurdi.Inventory.Infrastructure.csproj -o Data/Migrations
     dotnet ef database update  --context AppDbContext -p ../Kurdi.Inventory.Infrastructure/Kurdi.Inventory.Infrastructure.csproj 
**/

