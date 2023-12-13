using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases;

public record ListProductsQuery(ListProductsRequest listProductsRequest) : IQuery<Result<IEnumerable<ListProductsItemResponse>>>;

