
using System.Threading.Tasks;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
using Kurdi.Inventory.Core.SalesOrders;

namespace Kurdi.Inventory.Core.Contracts.Repositories
{
    public interface ISalesOrdersRepo : IRepoBase<SalesOrder>
    {
        SalesOrder CreateOrder(SalesOrderDto salesOrderDTO);
    }
}
