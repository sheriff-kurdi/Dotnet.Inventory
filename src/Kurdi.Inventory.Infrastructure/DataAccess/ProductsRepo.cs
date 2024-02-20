using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Contracts.Repositories;

namespace Kurdi.Inventory.Infrastructure.DataAccess
{
    public class ProductsRepo(AppDbContext db) : RepoBase<Product>(db), IProductsRepo;
}
