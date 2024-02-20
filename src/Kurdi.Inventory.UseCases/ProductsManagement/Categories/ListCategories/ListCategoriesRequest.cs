namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.ListCategories;

public class ListCategoriesRequest : PaginatedRequest
{
    private string? _query;

    public string? Query
    {
        get => _query;
        set => _query = value?.ToLower();
    }

    public bool Activation { get; set; }
}
