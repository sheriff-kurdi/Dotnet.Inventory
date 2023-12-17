using System;
using System.Linq;
using System.Threading.Tasks;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using MediatR;

namespace Kurdi.Inventory.Core;

public class ReceivingService : IReceivingService
{
    private readonly IProductsRepo _productsRepo;
    private readonly IMediator _mediator;

    public ReceivingService(IProductsRepo productsRepo, IMediator mediator)
    {
        _productsRepo = productsRepo;
        _mediator = mediator;
    }

    public async Task ReceiveProduct(string sku, int quantity)
    {
        Product product = _productsRepo.Find(product => product.Sku == sku).FirstOrDefault();
        product.ProductQuantity.AddStock(quantity);

        _productsRepo.Update(product);

        var domainEvent = new ReceiveProductEvent(sku, quantity);
        await _mediator.Publish(domainEvent);
        
        await _productsRepo.SaveChangesAsync();
    }
}
