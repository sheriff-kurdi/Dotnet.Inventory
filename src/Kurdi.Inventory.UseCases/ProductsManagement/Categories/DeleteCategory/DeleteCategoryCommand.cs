using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.DeleteCategory;

public record DeleteCategoryCommand(string Name) : ICommand<Result<string>>;
