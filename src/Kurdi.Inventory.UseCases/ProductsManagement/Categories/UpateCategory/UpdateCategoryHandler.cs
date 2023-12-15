using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;
using Microsoft.EntityFrameworkCore;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class UpdateCategoryHandler : ICommandHandler<UpdateCategoryCommand, Result>
{

    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IValidator<UpdateCategoryRequest> _validator;

    public UpdateCategoryHandler(ICategoriesRepo categoriesRepo, IValidator<UpdateCategoryRequest> validator)
    {
        _categoriesRepo = categoriesRepo;
        _validator = validator;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request.updateCategoryRequest);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        if (request.categoryName != request.updateCategoryRequest.Name) return Result.Error(["category name not the same"]);

        Category? actualCategory = await _categoriesRepo.Find(category => category.Name == request.updateCategoryRequest.Name).FirstOrDefaultAsync();
        if (actualCategory == null) return Result.NotFound();

        _categoriesRepo.Update(request.updateCategoryRequest.ToCategory());
        await _categoriesRepo.SaveChangesAsync();
        return Result.Success();
    }
}