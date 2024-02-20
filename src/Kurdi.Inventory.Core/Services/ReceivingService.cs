using System.Linq;
using System.Threading.Tasks;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Contracts.Services;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.Core.Events.Receiving.ReceiveProduct;
using MediatR;

namespace Kurdi.Inventory.Core.Services;

public class ReceivingService(IProductsRepo productsRepo, IMediator mediator) : IReceivingService
{
    public async Task ReceiveProduct(string sku, int quantity)
    {
        Product product = productsRepo.Find(product => product.Sku == sku).FirstOrDefault();
        if (product != null)
        {
            product.ProductQuantity.AddStock(quantity);
            productsRepo.Update(product);
        }

        var domainEvent = new ReceiveProductEvent(sku, quantity);
        await mediator.Publish(domainEvent);

        await productsRepo.SaveChangesAsync();
    }
}
