
namespace Kurdi.Inventory.Api.Requests.Stock;

public class CategoriesRequestParameters : BaseRequestParameters
{
    private string? _query;

    public string? Query
    {
        get => _query;
        set => _query = value?.ToLower();
    }

}
