using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.UpdateCategory;

public record UpdateCategoryCommand(string CategoryName, UpdateCategoryRequest UpdateCategoryRequest) : ICommand<Result>;
