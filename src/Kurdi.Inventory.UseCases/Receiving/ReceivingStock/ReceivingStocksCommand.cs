

using Kurdi.Inventory.Core;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.Receiving;
public record ReceivingStocksCommand(ReceiveProductDTO ReceiveProductDTO) : ICommand<Result>;
