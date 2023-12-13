using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public record GetCategoryByNameQuery(string name) : IQuery<Result<GetCategoryByNameResponse>>;