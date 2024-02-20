using Kurdi.Inventory.Core;
using Kurdi.Inventory.Core.DTOs.Receiving;

namespace Kurdi.Inventory.Api.Requests.Receiving;

public class ReceiveProductRequest
{
    public string SKU { get; init; } = string.Empty;
    public int quantity { get; init; }

    public ReceiveProductDto ToReceiveProductDTO()
    {
        return new ReceiveProductDto(SKU, quantity);
    }
}
