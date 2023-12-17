using System.Text.Json.Serialization;

namespace Kurdi.Inventory.Core.Entities.CategoryAggregate
{
    public class CategoryDetails
    {
        public string LanguageCode { get; set; }
        [JsonIgnore]
        public Language Language { get; set; }
        public string CategoryName { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public string TranslatedName { get; set; }
        public string Description { get; set; }
        public TimeStamps TimeStamps { get; set; }
    }
}