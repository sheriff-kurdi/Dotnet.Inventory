using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.CreateProduct;

public class CreateProductRequest
{
    public string SKU { get; set; } = string.Empty;
    public ProductPrices ProductPrices { get; set; } = new ProductPrices();
    public List<ProductDetails> ProductDetails { get; set; } = [];
    public string CategoryName { get; set; } = string.Empty;
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
