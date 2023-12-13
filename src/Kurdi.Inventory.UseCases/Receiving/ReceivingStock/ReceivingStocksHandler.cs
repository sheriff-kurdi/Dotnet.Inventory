
using Kurdi.Inventory.Core;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using MediatR;

namespace Kurdi.Inventory.UseCases.Receiving;

public class ReceivingStocksHandler : ICommandHandler<ReceivingStocksCommand, Result>
{
  private readonly IReceivingService _receivingService;

  public ReceivingStocksHandler(IReceivingService receivingService)
  {
    _receivingService = receivingService;
  }

    public async Task<Result> Handle(ReceivingStocksCommand request, CancellationToken cancellationToken)
    {
      await _receivingService.ReceiveProduct(request.ReceiveProductDTO.sku, request.ReceiveProductDTO.quantity);
      return Result.Success();
    }

 
}