using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public record ListCategoriesQuery(ListCategoriesRequest listCategoriesRequest) : IQuery<Result<IEnumerable<ListCategoriesItemResponse>>>;

