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
        [Column(name: "id")]
        public int Id { get; set; }
        [ForeignKey("SalesOrder")]
        [Column(name: "sales_order_id")]
        public int SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }
        [ForeignKey("Product")]
        [Column(name: "sku")]
        public string SKU { get; set; }
        public Product Product { get; set; }
        [Column(name: "cost_price_per_item")]
        public double CostPricePerItem { get; set; }
        [Column(name: "selling_price_per_item")]
        public double SellingPricePerItem { get; set; }
        [Column(name: "discount_per_item")]
        public double DiscountPerItem { get; set; }
        [Column(name: "selling_price_per_item_before_discount")]
        public double SellingPricePerItemBeforeDiscount { get; set; }
        [Column(name: "quantity")]
        public int Quantity { get; set; }

    }
}