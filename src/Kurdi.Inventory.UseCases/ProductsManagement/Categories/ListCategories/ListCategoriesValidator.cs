using FluentValidation;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.ListCategories;

public class ListCategoriesValidator : AbstractValidator<ListCategoriesRequest>
{
    public ListCategoriesValidator()
    {
        //RuleFor(x => x.Query).NotEmpty();

    }
}
