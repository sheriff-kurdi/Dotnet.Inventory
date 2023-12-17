using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Kurdi.Inventory.Core.Entities.ProductAggregate
{
    public class ProductDetails
    {
        public string LanguageCode { get; set; }
        [JsonIgnore]
        public Language Language { get; set; }
        public string Sku { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeStamps TimeStamps { get; set; }

    }
}