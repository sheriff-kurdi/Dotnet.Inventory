using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.CreateCategory;

public class CreateCategoryHandler(ICategoriesRepo categoriesRepo, IValidator<CreateCategoryRequest> validator)
    : ICommandHandler<CreateCategoryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await validator.ValidateAsync(request.CreateCategoryRequest, cancellationToken);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        await categoriesRepo.CreateAsync(request.CreateCategoryRequest.ToCategory());
        await categoriesRepo.SaveChangesAsync();
        return Result.Success(request.CreateCategoryRequest.Name);

    }
}