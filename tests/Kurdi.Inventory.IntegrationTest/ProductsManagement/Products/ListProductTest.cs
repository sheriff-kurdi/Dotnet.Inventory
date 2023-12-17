

using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace Kurdi.Inventory.IntegrationTest.ProductsManagement.Products
{
    public class ListProductTest : BaseIntegrationTest
    {
        private readonly IntegrationTestWebAppFactory _factory;

        public ListProductTest(IntegrationTestWebAppFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task List_EndpointsReturnSuccess()
        {
            // Arrange
            var client = _factory.CreateClient();
            string url = "/api/products-management/products?PageNumber=1&PageSize=10";

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
