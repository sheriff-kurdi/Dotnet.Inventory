using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public class GetProductBySKUHandler : IQueryHandler<GetProductBySKUQuery, Result<GetProductBySKUResponse>>
{
    private readonly IProductsRepo _productsRepo;

    public GetProductBySKUHandler(IProductsRepo productsRepo)
    {
        _productsRepo = productsRepo;
    }

    public async Task<Result<GetProductBySKUResponse>> Handle(GetProductBySKUQuery request, CancellationToken cancellationToken)
    {
        GetProductBySKUResponse? product = await _productsRepo
            .Find(product => product.Sku == request.sku)
            .Include(stock => stock.ProductDetails)
            .Select(product => new GetProductBySKUResponse()
            {
                Sku = product.Sku,
                ProductPrices = product.ProductPrices,
                ProductDetails = product.ProductDetails,
                ProductQuantity = product.ProductQuantity,
                Activation = product.Activation,
                CategoryName = product.CategoryName,
                SupplierIdentity = product.SupplierIdentity
            })
            .FirstOrDefaultAsync();


        if (product == null) return Result.NotFound();

        return Result.Success<GetProductBySKUResponse>(product);
    }
}
