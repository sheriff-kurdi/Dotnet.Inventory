using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Kurdi.Inventory.Core;

public sealed class RevceiveProductHandler : INotificationHandler<ReceiveProductEvent>
{
    private readonly ILogger<RevceiveProductHandler> _logger;

    public RevceiveProductHandler(ILogger<RevceiveProductHandler> logger)
    {
        _logger = logger;
    }
    public async Task Handle(ReceiveProductEvent domainEvent, CancellationToken cancellationToken)
    {
        _logger.LogInformation("We received product {sku} with quantity {quantity} at {date}", domainEvent.SKU, domainEvent.Quantity, domainEvent.DateOccurred);
        await Task.Delay(1);

    }
}
