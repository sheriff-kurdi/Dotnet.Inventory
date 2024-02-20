using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.ListProducts;

public class ListProductHandler(IProductsRepo productsRepo, IValidator<ListProductsRequest> validator)
    : IQueryHandler<ListProductsQuery, Result<IEnumerable<ListProductsItemResponse>>>
{
    public async Task<Result<IEnumerable<ListProductsItemResponse>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {

        ValidationResult validationResult = await validator.ValidateAsync(request.ListProductsRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }


        var products = productsRepo.FindAll();


        products = products
            .Include(s => s.ProductDetails);


        if (!string.IsNullOrEmpty(request.ListProductsRequest.Sku))
        {
            products = products.Where(p => p.Sku == request.ListProductsRequest.Sku);
        }
        if (!string.IsNullOrEmpty(request.ListProductsRequest.Category))
        {
            products = products.Where(p => p.CategoryName == request.ListProductsRequest.Category);
        }
        if (!string.IsNullOrEmpty(request.ListProductsRequest.Name))
        {
            products = products.Where(p => p.ProductDetails.Any(pd => pd.Name == request.ListProductsRequest.Name));
        }
        if (!string.IsNullOrEmpty(request.ListProductsRequest.Query))
        {

            products = products.Where(p =>
                 p.Sku == request.ListProductsRequest.Query
                || p.ProductDetails.Any(pd => pd.Name.Contains(request.ListProductsRequest.Query)));
        }

        var pagedInfo = new PagedInfo(
                    request.ListProductsRequest.PageNumber
                    , request.ListProductsRequest.PageSize
                    , (int)Math.Ceiling(products.Count() / (double)request.ListProductsRequest.PageSize)
                    , products.Count());


        var productsResponse = products
            .Skip((request.ListProductsRequest.PageNumber - 1) * request.ListProductsRequest.PageSize)
            .Take(request.ListProductsRequest.PageSize)
            .Select(product => new ListProductsItemResponse()
            {
                Sku = product.Sku,
                ProductPrices = product.ProductPrices,
                ProductDetails = product.ProductDetails,
                ProductQuantity = product.ProductQuantity,
                Activation = product.Activation,
                CategoryName = product.CategoryName,
                SupplierIdentity = product.SupplierIdentity
            });



        var result = new PagedResult<IEnumerable<ListProductsItemResponse>>(pagedInfo, productsResponse);
        return await Task.FromResult(result);


    }
}
