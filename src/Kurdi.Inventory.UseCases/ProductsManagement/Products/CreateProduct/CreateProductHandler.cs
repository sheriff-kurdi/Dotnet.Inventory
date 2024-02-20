using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.CreateProduct;

public class CreateProductHandler(IProductsRepo productsRepo, IValidator<CreateProductRequest> validator)
    : ICommandHandler<CreateProductCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request.CreateProductRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        //TODO:add supplier id to the product and handle timestamps
        await productsRepo.CreateAsync(request.CreateProductRequest.ToProduct());
        await productsRepo.SaveChangesAsync();
        return Result.Success(request.CreateProductRequest.SKU);

    }
}