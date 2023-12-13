using Microsoft.EntityFrameworkCore;
using Kurdi.Inventory.Core.Entities;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Microsoft.Extensions.Configuration;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using System.Threading.Tasks;
using System.Threading;
using Kurdi.SharedKernel;
using System.Linq;

namespace Kurdi.Inventory.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        // private readonly IDomainEventDispatcher _dispatcher;

        // public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration, IDomainEventDispatcher dispatcher) : base(options)
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            // _dispatcher = dispatcher;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseSqlServer(_configuration.GetConnectionString("sqlServerDatabase"));

            //options.UseNpgsql(_configuration.GetConnectionString("postgresDatabase"));

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductDetails>().HasKey(details => new { details.LanguageCode, details.Sku });
            builder.Entity<CategoryDetails>().HasKey(details => new { details.LanguageCode, details.TranslatedName });
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //       => options.UseMySQL(configuration["db_conn"]);
        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetails> CategoriesDetails { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderProduct> SalesOrderProducts { get; set; }
        public DbSet<SalesOrderStatus> SalesOrderStatuses { get; set; }


    }
}
/***
     dotnet ef migrations add InitialMigration-naming --context AppDbContext -p ../Kurdi.Inventory.Infrastructure/Kurdi.Inventory.Infrastructure.csproj -o Data/Migrations
     dotnet ef database update  --context AppDbContext -p ../Kurdi.Inventory.Infrastructure/Kurdi.Inventory.Infrastructure.csproj 
**/

