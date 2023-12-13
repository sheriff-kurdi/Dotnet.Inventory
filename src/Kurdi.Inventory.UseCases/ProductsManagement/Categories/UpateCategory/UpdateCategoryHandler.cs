using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.Inventory.Core.Entities.ProductAggregate;
using Kurdi.Inventory.UseCases.ProductsManagement.Products;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryCommand, Result>
{

    private readonly ICategoriesRepo _categoriesRepo;

    public UpdateCategoryHandler(ICategoriesRepo categoriesRepo)
    {
        _categoriesRepo = categoriesRepo;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.categoryName != request.updateCategoryRequest.Name) return Result.Error(["category name not the same"]);

        Category? actualCategory = await _categoriesRepo.Find(category => category.Name == request.updateCategoryRequest.Name).FirstOrDefaultAsync();
        if (actualCategory == null) return Result.NotFound();

        _categoriesRepo.Update(request.updateCategoryRequest.ToCategory());
        await _categoriesRepo.SaveChangesAsync();
        return Result.Success();
    }
}