using FluentValidation;
using Kurdi.Inventory.UseCases.ProductsManagement.CommonValidators;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Products;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.SKU).NotEmpty();
        RuleFor(x => x.CategoryName).NotEmpty();

        RuleFor(x => x.ProductPrices.SellingPrice).GreaterThan(0);
        RuleFor(x => x.ProductPrices.CostPrice).GreaterThan(0);
        RuleFor(x => x.ProductPrices.Discount).GreaterThan(0).When(x => x.ProductPrices.IsDiscounted);

        RuleForEach(x => x.ProductDetails).SetValidator(new ProductDetailsValidator());
    }
}


