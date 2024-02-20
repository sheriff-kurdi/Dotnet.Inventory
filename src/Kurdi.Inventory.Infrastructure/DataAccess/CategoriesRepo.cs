using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Contracts.Repositories;

namespace Kurdi.Inventory.Infrastructure.DataAccess
{
    public class CategoriesRepo(AppDbContext db) : RepoBase<Category>(db), ICategoriesRepo;
}
