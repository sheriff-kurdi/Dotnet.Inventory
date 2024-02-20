using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.DeleteProduct;

public class DeleteProductHandler(IProductsRepo productsRepo) : ICommandHandler<DeleteProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        Product? product = productsRepo.Find(stock => stock.Sku == request.Sku).FirstOrDefault();
        if (product is null) return Result.NotFound();

        productsRepo.Delete(product);
        await productsRepo.SaveChangesAsync();
        return Result.Success(request.Sku);
    }


}