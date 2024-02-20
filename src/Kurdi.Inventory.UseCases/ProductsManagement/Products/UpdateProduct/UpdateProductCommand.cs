using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.UpdateProduct;

public record UpdateProductCommand(string Sku, UpdateProductRequest UpdateProductRequest) : ICommand<Result>;
