using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.GetProductBySKU;

public class GetProductBySkuHandler(IProductsRepo productsRepo)
    : IQueryHandler<GetProductBySkuQuery, Result<GetProductBySkuResponse>>
{
    public async Task<Result<GetProductBySkuResponse>> Handle(GetProductBySkuQuery request, CancellationToken cancellationToken)
    {
        GetProductBySkuResponse? product = await productsRepo
            .Find(product => product.Sku == request.Sku)
            .Include(stock => stock.ProductDetails)
            .Select(product => new GetProductBySkuResponse()
            {
                Sku = product.Sku,
                ProductPrices = product.ProductPrices,
                ProductDetails = product.ProductDetails,
                ProductQuantity = product.ProductQuantity,
                Activation = product.Activation,
                CategoryName = product.CategoryName,
                SupplierIdentity = product.SupplierIdentity
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);


        if (product == null) return Result.NotFound();

        return Result.Success(product);
    }
}
