using Kurdi.Inventory.Infrastructure.Data;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Core.DTOs.SalesOrders;
using Kurdi.Inventory.Core.Contracts.Repositories;

namespace Kurdi.Inventory.Infrastructure.DataAccess
{
    public class SalesOrdersRepo : RepoBase<SalesOrder>, ISalesOrdersRepo
    {
        public SalesOrdersRepo(AppDbContext db) : base(db)
        {

        }

        public SalesOrder CreateOrder(SalesOrderDTO salesOrderDTO)
        {
            return new SalesOrder();
        }
    }
}
