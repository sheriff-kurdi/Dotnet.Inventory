using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Kurdi.Inventory.Core.Events.Receiving.ReceiveProduct;

public sealed class ReceiveProductHandler(ILogger<ReceiveProductHandler> logger)
    : INotificationHandler<ReceiveProductEvent>
{
    public async Task Handle(ReceiveProductEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("We received product {sku} with quantity {quantity} at {date}", domainEvent.Sku, domainEvent.Quantity, domainEvent.DateOccurred);
        await Task.Delay(1, cancellationToken);

    }
}
