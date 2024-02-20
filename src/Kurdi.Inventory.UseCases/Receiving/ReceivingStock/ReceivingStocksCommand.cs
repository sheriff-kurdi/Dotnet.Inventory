using Kurdi.Inventory.Core.DTOs.Receiving;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.Receiving.ReceivingStock;
public record ReceivingStocksCommand(ReceiveProductDto ReceiveProductDto) : ICommand<Result>;
