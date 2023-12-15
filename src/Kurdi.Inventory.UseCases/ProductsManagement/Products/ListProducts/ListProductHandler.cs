using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public class ListProductHandler : IQueryHandler<ListProductsQuery, Result<IEnumerable<ListProductsItemResponse>>>
{
    private readonly IProductsRepo _productsRepo;
    private readonly IValidator<ListProductsRequest> _validator;

    public ListProductHandler(IProductsRepo productsRepo, IValidator<ListProductsRequest> validator)
    {
        _productsRepo = productsRepo;
        _validator = validator;
    }
    public async Task<Result<IEnumerable<ListProductsItemResponse>>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {

        ValidationResult validationResult = await _validator.ValidateAsync(request.listProductsRequest);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }
        

        var products = _productsRepo.FindAll();


        products = products
            .Include(s => s.ProductDetails);


        if (!string.IsNullOrEmpty(request.listProductsRequest.Sku))
        {
            products = products.Where(p => p.SKU == request.listProductsRequest.Sku);
        }
        if (!string.IsNullOrEmpty(request.listProductsRequest.Category))
        {
            products = products.Where(p => p.CategoryName == request.listProductsRequest.Category);
        }
        if (!string.IsNullOrEmpty(request.listProductsRequest.Name))
        {
            products = products.Where(p => p.ProductDetails.Any(pd => pd.Name == request.listProductsRequest.Name));
        }
        if (!string.IsNullOrEmpty(request.listProductsRequest.Query))
        {

            products = products.Where(p =>
                 p.SKU == request.listProductsRequest.Query
                || p.ProductDetails.Any(pd => pd.Name.Contains(request.listProductsRequest.Query)));
        }

        var pagedInfo = new PagedInfo(
                    request.listProductsRequest.PageNumber
                    , request.listProductsRequest.PageSize
                    , (int)Math.Ceiling(products.Count() / (double)request.listProductsRequest.PageSize)
                    , products.Count());


        var productsResponse = products
            .Skip((request.listProductsRequest.PageNumber - 1) * request.listProductsRequest.PageSize)
            .Take(request.listProductsRequest.PageSize)
            .Select(product => new ListProductsItemResponse(){
                SKU = product.SKU,
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
