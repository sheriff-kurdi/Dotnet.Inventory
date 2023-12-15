
using System.Reflection;
using Kurdi.Inventory.Core;
using Kurdi.Inventory.UseCases;

namespace Kurdi.Inventory.Api.Configurations;

public class MediatorConfig
{
    public static IEnumerable<Assembly> GetAssemblies()
    {
        yield return typeof(UseCaseRoot).GetTypeInfo().Assembly;
        yield return typeof(CoreRoot).GetTypeInfo().Assembly;
    }
}
