using System;
using System.Collections.Generic;
using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.Core;

public class UpdateProductDTO
{
    public string SKU { get; set; }
    public int SupplierIdentity { get; set; }
    public ProductPrices ProductPrices { get; set; }
    public List<ProductDetails> ProductDetails { get; set; } = new List<ProductDetails>();
    public string CategoryName { get; set; }
    public bool Activation { get; set; }

    public Product ToProduct()
    {
        return new Product()
        {
            Sku = SKU,
            ProductPrices = ProductPrices,
            CategoryName = CategoryName,
            Activation = Activation
        };
    }
}
