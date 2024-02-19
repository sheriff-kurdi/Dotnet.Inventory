using Kurdi.Inventory.Core;

namespace Kurdi.Inventory.Api.Requests.Receiving;

public class ReceiveProductRequest
{
    public string SKU { get; init; } = string.Empty;
    public int quantity { get; init; }

    public ReceiveProductDTO ToReceiveProductDTO()
    {
        return new ReceiveProductDTO(SKU, quantity);
    }
}
