using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Kurdi.Inventory.Core.Entities.ProductAggregate
{
    [Table(name: "product_details")]
    public class ProductDetails
    {
        [Column(name: "language_code")]
        public string LanguageCode { get; set; }
        [ForeignKey(name: "LanguageCode")]
        [JsonIgnore]
        public Language Language { get; set; }

        [Column(name: "sku")]
        public string Sku { get; set; }
        [ForeignKey(name: "Sku")]
        [JsonIgnore]
        public Product Product { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "description")]
        public string Description { get; set; }
        public TimeStamps TimeStamps { get; set; }

    }
}