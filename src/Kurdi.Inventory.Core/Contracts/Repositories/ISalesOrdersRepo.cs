
using System.Threading.Tasks;
using Kurdi.Inventory.Core.DTOs.SalesOrders;
using Kurdi.Inventory.Core.Entities.SalesOrderAggregate;
namespace Kurdi.Inventory.Core.Contracts.Repositories
{
    public interface ISalesOrdersRepo : IRepoBase<SalesOrder>
    {
        SalesOrder CreateOrder(SalesOrderDTO salesOrderDTO);
    }
}
