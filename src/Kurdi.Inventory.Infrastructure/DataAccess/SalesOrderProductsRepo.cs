using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Core.Contracts.Repositories;

namespace Kurdi.Inventory.Infrastructure.DataAccess
{
    public class SalesOrderProductsRepo : RepoBase<SalesOrderProduct>, ISalesOrderProductsRepo
    {
        public SalesOrderProductsRepo(AppDbContext db) : base(db)
        {

        }
    }
}
