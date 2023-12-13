using System;
using System.Threading.Tasks;

namespace Kurdi.Inventory.Core;

public interface IReceivingService
{
    Task ReceiveProduct(string sku, int quantity);
}
