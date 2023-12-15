using FluentValidation;
using Kurdi.Inventory.UseCases.ProductsManagement.CommonValidators;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ParentName).NotEmpty().When(x => x.HasParent);

        RuleForEach(x => x.CategoryDetails).SetValidator(new CategoryDetailsValidator());
    }
}
