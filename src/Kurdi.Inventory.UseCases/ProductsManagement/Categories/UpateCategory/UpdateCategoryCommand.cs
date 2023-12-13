using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public record UpdateCategoryCommand(string categoryName, UpdateCategoryRequest updateCategoryRequest) : ICommand<Result>;
