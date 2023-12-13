using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public record CreateCategoryCommand(CreateCategoryRequest createCategoryRequest) : ICommand<Result<string>>;
