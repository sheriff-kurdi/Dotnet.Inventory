using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Kurdi.Inventory.Api.Helpers
{
    public class Translator
    {
        public static string Translate(string key)
        {
            var configrarion = new ConfigurationBuilder().AddJsonFile("Resourses/resourses.ar.json").Build();
            return configrarion.GetValue<string>(key) ?? key;
        }
    }
}