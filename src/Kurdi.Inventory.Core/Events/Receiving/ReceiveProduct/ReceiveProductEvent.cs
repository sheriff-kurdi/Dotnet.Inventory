using Kurdi.SharedKernel;

namespace Kurdi.Inventory.Core;

public sealed class ReceiveProductEvent(string sku, int quantity) : DomainEventBase
{
    public string SKU { get; init; } = sku;
    public int Quantity { get; init; } = quantity;
}
