using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.DeleteProduct;

public record DeleteProductCommand(string Sku) : ICommand<Result<string>>;
