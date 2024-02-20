using System.Collections.Generic;
using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.Core.DTOs.ProductsManagement.Products;

public class UpdateProductDto
{
    public string Sku { get; set; }
    public int SupplierIdentity { get; set; }
    public ProductPrices ProductPrices { get; set; }
    public List<ProductDetails> ProductDetails { get; set; } = [];
    public string CategoryName { get; set; }
    public bool Activation { get; set; }

    public Product ToProduct()
    {
        return new Product()
        {
            Sku = Sku,
            ProductPrices = ProductPrices,
            CategoryName = CategoryName,
            Activation = Activation
        };
    }
}
