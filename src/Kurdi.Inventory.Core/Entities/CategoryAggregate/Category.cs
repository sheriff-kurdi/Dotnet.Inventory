using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.Inventory.Core.Entities.CategoryAggregate;

public class Category : IAggregateRoot
{
    public string Name { get; set; } = string.Empty;
    public bool HasParent { get; set; }
    public string ParentName { get; set; }
    public Category Parent { get; set; }
    public List<CategoryDetails> CategoryDetails { get; set; } = new List<CategoryDetails>();
    public bool Activation { get; set; }
    public TimeStamps TimeStamps { get; set; }
}