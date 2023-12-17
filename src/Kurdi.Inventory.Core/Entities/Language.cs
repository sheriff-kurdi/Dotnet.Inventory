using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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