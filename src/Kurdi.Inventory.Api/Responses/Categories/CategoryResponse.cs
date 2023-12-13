using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.Api.Responses.Categories;

public record CategoryResponse
{
    public string Name { get; set; } = string.Empty;
    public string TranslatedName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsParent { get; set; }
    public string Parent { get; set; } = string.Empty;

}