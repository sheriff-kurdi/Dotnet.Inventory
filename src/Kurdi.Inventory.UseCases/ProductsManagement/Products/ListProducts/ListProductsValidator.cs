using FluentValidation;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products.ListProducts;

public class ListProductsValidator : AbstractValidator<ListProductsRequest>
{
    public ListProductsValidator()
    {
        //RuleFor(x => x.Sku).NotEmpty();
        //RuleFor(x => x.Category).NotEmpty();
        //RuleFor(x => x.Name).NotEmpty();
        //RuleFor(x => x.Query).NotEmpty();
    }
}
