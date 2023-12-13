using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.Api.Responses.Stock;

public record StockItemResponse
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public ProductPrices ProductPrices { get; set; } = new ProductPrices();
    public ProductQuantity ProductQuantity { get; set; } = new ProductQuantity();
}