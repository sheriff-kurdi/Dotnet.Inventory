using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.GetProductBySKU;

public record GetProductBySkuQuery(string Sku) : IQuery<Result<GetProductBySkuResponse>>;