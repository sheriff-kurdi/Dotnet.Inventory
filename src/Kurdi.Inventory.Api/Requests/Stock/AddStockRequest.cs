using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.Inventory.Api.Requests.Stock
{
    public class AddStockRequest
    {
        public string SKU { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double TotalCost { get; set; }
    }
}