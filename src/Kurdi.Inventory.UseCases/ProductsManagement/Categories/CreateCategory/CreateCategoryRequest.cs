using Kurdi.Inventory.Core.Entities.CategoryAggregate;

namespace Kurdi.Inventory.UseCases.ProductsManagement.Categories.CreateCategory;

public abstract class CreateCategoryRequest
{

    public string Name { get; set; } = string.Empty;
    public bool HasParent { get; set; }
    public string ParentName { get; set; } = string.Empty;
    public List<CategoryDetails> CategoryDetails { get; set; } = [];
    public bool Activation { get; set; }

    public Category ToCategory()
    {
        return new Category()
        {
            Name = Name,
            HasParent = HasParent,
            ParentName = ParentName,
            CategoryDetails = CategoryDetails,
            Activation = Activation

        };
    }
}
