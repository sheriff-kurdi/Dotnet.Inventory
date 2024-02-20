using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.ListCategories;

public record ListCategoriesQuery(ListCategoriesRequest ListCategoriesRequest) : IQuery<Result<IEnumerable<ListCategoriesItemResponse>>>;

