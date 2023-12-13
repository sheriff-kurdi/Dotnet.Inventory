using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;

namespace Kurdi.Inventory.Core.Entities.ProductAggregate
{
    [Table(name: "products")]
    public class Product : IAggregateRoot
    {
        [Key]
        [Column(name: "sku")]
        public string SKU { get; set; }
        [Column(name: "supplier_identity")]
        public int SupplierIdentity { get; set; }
        public ProductPrices ProductPrices { get; set; }
        public ProductQuantity ProductQuantity { get; set; }
        public List<ProductDetails> ProductDetails { get; set; } = new List<ProductDetails>();
        [Column(name: "category")]
        public string CategoryName { get; set; }
        [ForeignKey(name: "CategoryName")]
        public Category Category { get; set; }
        [Column(name: "activation")]
        public bool Activation { get; set; }
        public TimeStamps TimeStamps { get; set; }

    }
}
