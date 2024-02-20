using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.CreateProduct;

public record CreateProductCommand(CreateProductRequest CreateProductRequest) : ICommand<Result<string>>;
