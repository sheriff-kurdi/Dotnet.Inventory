using Kurdi.Inventory.Core.Contracts;
using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Contracts.Repositories;

namespace Kurdi.Inventory.Infrastructure.DataAccess
{
    public class CategoriesRepo : RepoBase<Category> , ICategoriesRepo
    {
        public CategoriesRepo(AppDbContext db) : base(db)
        {

        }
    }
}
