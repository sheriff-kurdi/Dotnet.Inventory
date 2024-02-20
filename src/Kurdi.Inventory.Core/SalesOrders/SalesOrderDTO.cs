using System.Collections.Generic;

namespace Kurdi.Inventory.Core.SalesOrders
{
    public class SalesOrderDto(List<SalesOrderItemDto> salesOrderItems)
    {
        public List<SalesOrderItemDto> SalesOrderItems { get; set; } = salesOrderItems;
    }
}