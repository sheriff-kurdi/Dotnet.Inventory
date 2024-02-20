using Kurdi.SharedKernel;

namespace Kurdi.Inventory.Core.Events.Receiving.ReceiveProduct;

public sealed class ReceiveProductEvent(string sku, int quantity) : DomainEventBase
{
    public string Sku { get; init; } = sku;
    public int Quantity { get; init; } = quantity;
}
