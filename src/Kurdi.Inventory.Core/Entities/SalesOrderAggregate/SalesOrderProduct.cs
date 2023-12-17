using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.Core.Entities.SalesOrderAggregate
{
    [Table(name: "sales_order_products")]
    public class SalesOrderProduct
    {
        public int Id { get; set; }
        [ForeignKey("SalesOrder")]
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        [ForeignKey("Product")]
        public string SKU { get; set; }
        public Product Product { get; set; }
        public double CostPricePerItem { get; set; }
        public double SellingPricePerItem { get; set; }
        public double DiscountPerItem { get; set; }
        public double SellingPricePerItemBeforeDiscount { get; set; }
        public int Quantity { get; set; }

    }
}