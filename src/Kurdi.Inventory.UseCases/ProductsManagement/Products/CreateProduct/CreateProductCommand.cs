using Kurdi.Inventory.Core;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public record CreateProductCommand(CreateProductRequest createProductRequest) : ICommand<Result<string>>;
