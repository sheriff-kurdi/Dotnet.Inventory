using Kurdi.Inventory.Core;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public record DeleteProductCommand(string sku) : ICommand<Result<string>>;
