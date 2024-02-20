using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.DeleteCategory;

public class DeleteCategoryHandler(ICategoriesRepo categoriesRepo)
    : ICommandHandler<DeleteCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = categoriesRepo.Find(category => category.Name == request.Name).FirstOrDefault();
        if (category is null) return Result.NotFound();

        categoriesRepo.Delete(category);
        await categoriesRepo.SaveChangesAsync();
        return Result.Success(request.Name);
    }


}