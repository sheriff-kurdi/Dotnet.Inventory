using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public record ListProductsQuery(ListProductsRequest listProductsRequest) : IQuery<Result<IEnumerable<ListProductsItemResponse>>>;

