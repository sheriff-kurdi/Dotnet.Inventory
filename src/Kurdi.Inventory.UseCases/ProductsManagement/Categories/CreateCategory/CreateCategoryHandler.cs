using FluentValidation;
using FluentValidation.Results;
using Kurdi.Inventory.Core.Contracts.Repositories;
using Kurdi.SharedKernel;
using Kurdi.SharedKernel.Result;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand, Result<string>>
{
    private readonly ICategoriesRepo _categoriesRepo;
    private readonly IValidator<CreateCategoryRequest> _validator;

    public CreateCategoryHandler(ICategoriesRepo categoriesRepo, IValidator<CreateCategoryRequest> validator)
    {
        _categoriesRepo = categoriesRepo;
        _validator = validator;
    }
    public async Task<Result<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        ValidationResult validationResult = await _validator.ValidateAsync(request.createCategoryRequest);
        if (!validationResult.IsValid)
        {
            return Result.Error(validationResult.Errors.Select(err => err.ErrorMessage).ToArray());
        }

        await _categoriesRepo.CreateAsync(request.createCategoryRequest.ToCategory());
        await _categoriesRepo.SaveChangesAsync();
        return Result.Success<string>(request.createCategoryRequest.Name);

    }
}