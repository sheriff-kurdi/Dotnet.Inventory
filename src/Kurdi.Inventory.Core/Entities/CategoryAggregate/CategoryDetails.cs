using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Kurdi.Inventory.Core.Entities.CategoryAggregate
{
    [Table(name: "categories_details")]
    public class CategoryDetails
    {
        [Column(name: "language_code")]
        public string LanguageCode { get; set; }
        [ForeignKey(name: "LanguageCode")]
        [JsonIgnore]
        public Language Language { get; set; }
        [Column(name: "name")]
        public string Name { get; set; }
        [ForeignKey(name: "Name")]
        [JsonIgnore]
        public Category Category { get; set; }
        [Column(name: "translated_name")]
        public string TranslatedName { get; set; }
        [Column(name: "description")]
        public string Description { get; set; }
        public TimeStamps TimeStamps { get; set; }
    }
}