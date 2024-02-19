using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class DeleteCategoryHandler : ICommandHandler<DeleteCategoryCommand, Result<string>>
{

    private readonly ICategoriesRepo _categoriesRepo;

    public DeleteCategoryHandler(ICategoriesRepo categoriesRepo)
    {
        _categoriesRepo = categoriesRepo;
    }

    public async Task<Result<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = _categoriesRepo.Find(category => category.Name == request.name).FirstOrDefault();
        if (category is null) return Result.NotFound();

        _categoriesRepo.Delete(category);
        await _categoriesRepo.SaveChangesAsync();
        return Result.Success<string>(request.name);
    }


}