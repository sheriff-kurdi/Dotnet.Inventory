using FluentValidation;
using Kurdi.Inventory.UseCases.ProductsManagement.CommonValidators;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.UpdateCategory;

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ParentName).NotEmpty().When(x => x.HasParent);

        RuleForEach(x => x.CategoryDetails).SetValidator(new CategoryDetailsValidator());
    }
}
