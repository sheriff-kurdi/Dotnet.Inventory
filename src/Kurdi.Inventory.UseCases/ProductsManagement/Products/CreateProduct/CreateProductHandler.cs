using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, Result<string>>
{
    private readonly IProductsRepo _productsRepo;
    private readonly IValidator<CreateProductRequest> _validator;

    public CreateProductHandler(IProductsRepo productsRepo, IValidator<CreateProductRequest> validator)
    {
        _productsRepo = productsRepo;
        _validator = validator;
    }
    public async Task<Result<string>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request.createProductRequest);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        //TODO:add supplier id to the product and handle timestamps
        await _productsRepo.CreateAsync(request.createProductRequest.ToProduct());
        await _productsRepo.SaveChangesAsync();
        return Result.Success<string>(request.createProductRequest.SKU);

    }
}