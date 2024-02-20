using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.ListProducts;

public record ListProductsQuery(ListProductsRequest ListProductsRequest) : IQuery<Result<IEnumerable<ListProductsItemResponse>>>;

