using FluentValidation;
using Kurdi.Inventory.Core.Entities.CategoryAggregate;

namespace Kurdi.Inventory.UseCases.ProductsManagement.CommonValidators;

public class CategoryDetailsValidator : AbstractValidator<CategoryDetails>
{

    public CategoryDetailsValidator()
    {
        RuleFor(x => x.CategoryName).NotEmpty();
        RuleFor(x => x.TranslatedName).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.LanguageCode).NotEmpty();
    }
}
