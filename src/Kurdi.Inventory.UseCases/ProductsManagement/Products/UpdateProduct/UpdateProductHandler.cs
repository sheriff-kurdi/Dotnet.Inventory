using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.UpdateProduct;

public class UpdateProductHandler(
    IProductsRepo productsRepo,
    ICategoriesRepo categoriesRepo,
    IValidator<UpdateProductRequest> validator)
    : ICommandHandler<UpdateProductCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {

        ValidationResult validationResult = await validator.ValidateAsync(request.UpdateProductRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        if (request.Sku != request.UpdateProductRequest.SKU) return Result.Error(["sku not the same"]);

        //TODO: handle response from here status code and type
        //TODO:handle timestamps

        //check if product exist
        Product? product = productsRepo.Find(stock => stock.Sku == request.UpdateProductRequest.SKU).FirstOrDefault();
        if (product is null) return Result.NotFound();

        //don't update product quantity
        //TODO: update details without delete a translation in updating coz the get get only one translation
        //product.ProductDetails = request.updateProductDTO.ProductDetails;
        product.Activation = request.UpdateProductRequest.Activation;
        product.ProductPrices = request.UpdateProductRequest.ProductPrices;
        Category? category = categoriesRepo.Find(category => category.Name == request.UpdateProductRequest.CategoryName).FirstOrDefault();
        //TODO: check the response of this behavior
        if (category is null) return Result.Error(["category not found"]);
        product.Category = category;
        product.CategoryName = request.UpdateProductRequest.CategoryName;


        productsRepo.Update(product);
        await productsRepo.SaveChangesAsync();
        return Result.Success();
    }
}