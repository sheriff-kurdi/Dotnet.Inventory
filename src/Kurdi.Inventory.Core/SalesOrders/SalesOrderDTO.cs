using System.Collections.Generic;


namespace Kurdi.Inventory.Core.DTOs.SalesOrders
{
    public class SalesOrderDTO
    {
        public List<SalesOrderItemDTO> SalesOrderItems { get; set; } = new List<SalesOrderItemDTO>();

        public SalesOrderDTO(List<SalesOrderItemDTO> salesOrderItems)
        {
            this.SalesOrderItems = salesOrderItems;
        }
    }
}