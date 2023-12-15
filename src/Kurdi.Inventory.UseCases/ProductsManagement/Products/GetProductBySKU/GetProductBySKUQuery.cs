using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public record GetProductBySKUQuery(string sku) : IQuery<Result<GetProductBySKUResponse>>;