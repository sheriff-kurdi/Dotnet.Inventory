namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.ListProducts;

public class ListProductsRequest : PaginatedRequest
{
    private string? _category;

    public string? Category
    {
        get => _category;
        set => _category = value?.ToUpper();
    }

    private string? _sku;

    public string? Sku
    {
        get => _sku;
        set => _sku = value?.ToLower();
    }

    private string? _name;

    public string? Name
    {
        get => _name;
        set => _name = value?.ToLower();
    }

    private string? _query;

    public string? Query
    {
        get => _query;
        set => _query = value?.ToLower();
    }
}
