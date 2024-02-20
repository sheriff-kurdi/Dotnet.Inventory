
namespace Kurdi.Inventory.Api.Helpers
{
    public class Translator
    {
        public static string Translate(string key)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("Resources/resources.ar.json").Build();
            return configuration.GetValue<string>(key) ?? key;
        }
    }
}