using Kurdi.Inventory.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Testcontainers.PostgreSql;
using Xunit;

namespace Kurdi.Inventory.IntegrationTest
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private readonly PostgreSqlContainer _postgresDbContainer = new PostgreSqlBuilder()
            .WithImage("mdillon/postgis")
            .WithDatabase("dotnet_inventory")
            .WithUsername("postgres")
            .WithPassword("password")
            .Build();

        

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var appDBContextDescriptor = services
                .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<AppDbContext>));

                if (appDBContextDescriptor != null )
                {
                    services.Remove(appDBContextDescriptor);
                }

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseNpgsql(_postgresDbContainer.GetConnectionString())
                    .UseSnakeCaseNamingConvention();
                });
            });
        }


        public Task InitializeAsync()
        {
            return _postgresDbContainer.StartAsync();
        }
        Task IAsyncLifetime.DisposeAsync()
        {
            return _postgresDbContainer.StopAsync();
        }
    }
}   
