using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, Result<string>>
{
    private readonly ICategoriesRepo _categoriesRepo;

    public CreateCategoryHandler(ICategoriesRepo categoriesRepo)
    {
        _categoriesRepo = categoriesRepo;
    }
    public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _categoriesRepo.CreateAsync(request.createCategoryRequest.ToCategory());
        await _categoriesRepo.SaveChangesAsync();
        return Result.Success<string>(request.createCategoryRequest.Name);

    }
}