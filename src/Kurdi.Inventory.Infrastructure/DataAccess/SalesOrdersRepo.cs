using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.SalesOrders;

namespace Kurdi.Inventory.Infrastructure.DataAccess
{
    public class SalesOrdersRepo(AppDbContext db) : RepoBase<SalesOrder>(db), ISalesOrdersRepo
    {
        public SalesOrder CreateOrder(SalesOrderDto salesOrderDto)
        {
            return new SalesOrder();
        }
    }
}
