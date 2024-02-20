using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.CreateCategory;

public record CreateCategoryCommand(CreateCategoryRequest CreateCategoryRequest) : ICommand<Result<string>>;
