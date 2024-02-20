using Kurdi.Inventory.Core.Contracts.Services;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.Receiving.ReceivingStock;

public class ReceivingStocksHandler(IReceivingService receivingService)
    : ICommandHandler<ReceivingStocksCommand, Result>
{
    public async Task<Result> Handle(ReceivingStocksCommand request, CancellationToken cancellationToken)
    {
        await receivingService.ReceiveProduct(request.ReceiveProductDto.Sku, request.ReceiveProductDto.Quantity);
        return Result.Success();
    }


}