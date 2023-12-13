using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public record DeleteCategoryCommand(string name) : ICommand<Result<string>>;
