namespace Kurdi.Inventory.Core.Entities
{
    public class Language
    {
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public bool Activation { get; set; }
        public TimeStamps TimeStamps { get; set; }

    }
}