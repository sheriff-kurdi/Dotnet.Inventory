using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.Inventory.Core.SalesOrders;

namespace Kurdi.Inventory.Api.Requests.SalesOrders
{
    public class SalesOrderRequest
    {
        public List<SalesOrderItemDto> SalesOrderItems { get; set; } = new List<SalesOrderItemDto>();
    }
}