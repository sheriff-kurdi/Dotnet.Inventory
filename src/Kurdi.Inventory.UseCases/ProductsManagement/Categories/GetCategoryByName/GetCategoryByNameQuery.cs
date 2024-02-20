using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.GetCategoryByName;

public record GetCategoryByNameQuery(string Name) : IQuery<Result<GetCategoryByNameResponse>>;