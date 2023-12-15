using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public class UpdateProductHandler : ICommandHandler<UpdateProductCommand, Result>
{

    private readonly IProductsRepo _productsRepo;
    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IValidator<UpdateProductRequest> _validator;

    public UpdateProductHandler(IProductsRepo productsRepo, ICategoriesRepo categoriesRepo, IValidator<UpdateProductRequest> validator)
    {
        _productsRepo = productsRepo;
        _categoriesRepo = categoriesRepo;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        ValidationResult validationResult = await _validator.ValidateAsync(request.updateProductRequest);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }
        
        if (request.sku != request.updateProductRequest.SKU) return Result.Error(["sku not the same"]);

        //TODO: handle response from here status code and type
        //TODO:handle timestamps

        //check if product exist
        Product? product = _productsRepo.Find(stock => stock.SKU == request.updateProductRequest.SKU).FirstOrDefault();
        if (product is null) return Result.NotFound();

        //don't update product quantity
        //TODO: update details without delete a translation in updating coz the get get only one translation
        //product.ProductDetails = request.updateProductDTO.ProductDetails;
        product.Activation = request.updateProductRequest.Activation;
        product.ProductPrices = request.updateProductRequest.ProductPrices;
        Category? category = _categoriesRepo.Find(category => category.Name == request.updateProductRequest.CategoryName).FirstOrDefault();
        //TODO: check the response of this bhavior
        if (category is null) return Result.Error(["category not found"]);
        product.Category = category;
        product.CategoryName = request.updateProductRequest.CategoryName;


        _productsRepo.Update(product);
        await _productsRepo.SaveChangesAsync();
        return Result.Success();
    }
}