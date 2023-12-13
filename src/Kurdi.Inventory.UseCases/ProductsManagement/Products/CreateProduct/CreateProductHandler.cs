using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.UseCases.ProductsManagement.Products;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, Result<string>>
{
    private readonly IProductsRepo _productsRepo;

    public CreateProductHandler(IProductsRepo productsRepo)
    {
        _productsRepo = productsRepo;
    }
    public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //TODO:add supplier id to the product and handle timestamps
        await _productsRepo.CreateAsync(request.createProductRequest.ToProduct());
        await _productsRepo.SaveChangesAsync();
        return Result.Success<string>(request.createProductRequest.SKU);

    }
}