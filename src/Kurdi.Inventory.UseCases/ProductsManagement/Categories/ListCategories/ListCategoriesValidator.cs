
using FluentValidation;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories;

public class ListCategoriesValidator  : AbstractValidator<ListCategoriesRequest>
{
    public ListCategoriesValidator()
    {
        //RuleFor(x => x.Query).NotEmpty();

    }
}
