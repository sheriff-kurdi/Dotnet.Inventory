using System.Threading.Tasks;

namespace Kurdi.Inventory.Core.Contracts.Services;

public interface IReceivingService
{
    Task ReceiveProduct(string sku, int quantity);
}
