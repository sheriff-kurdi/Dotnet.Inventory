using System.Collections.Generic;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;

namespace Kurdi.Inventory.Core.Entities.ProductAggregate
{
    public class Product : IAggregateRoot
    {
        public string Sku { get; set; }
        public int SupplierIdentity { get; set; }
        public ProductPrices ProductPrices { get; set; }
        public ProductQuantity ProductQuantity { get; set; }
        public List<ProductDetails> ProductDetails { get; set; } = new List<ProductDetails>();
        public string CategoryName { get; set; }
        public Category Category { get; set; }
        public bool Activation { get; set; }
        public TimeStamps TimeStamps { get; set; }

    }
}
