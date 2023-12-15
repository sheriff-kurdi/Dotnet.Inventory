using FluentValidation;
using Kurdi.Inventory.Core.Entities.ProductAggregate;

namespace Kurdi.Inventory.UseCases.ProductsManagement.CommonValidators;


public class ProductDetailsValidator : AbstractValidator<ProductDetails>
{

    public ProductDetailsValidator()
    {
        RuleFor(x => x.Sku).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.LanguageCode).NotEmpty();
    }
}
