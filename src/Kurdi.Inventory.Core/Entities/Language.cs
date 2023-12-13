using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kurdi.Inventory.Core.Entities
{
    [Table(name: "languages")]
    public class Language
    {
        [Key]
        [Column(name: "language_code")]
        public string LanguageCode { get; set; }
        [Column(name: "language_name")]
        public string LanguageName { get; set; }
        [Column(name: "activation")]
        public bool Activation { get; set; }
        [Column(name: "time_stamps")]
        public TimeStamps TimeStamps { get; set; }

    }
}