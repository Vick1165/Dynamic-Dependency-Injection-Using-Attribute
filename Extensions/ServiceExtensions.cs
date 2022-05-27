using Balaji.DependencyInjection.Core.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Balaji.DependencyInjection.Core.Extensions;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        var exe = Assembly.GetExecutingAssembly().Location;
        var path = Path.GetDirectoryName(exe);
        var assemblies = Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories).Select(e => { try { return Assembly.LoadFile(e); } catch (Exception ex) { } return null; }).ToList();

        foreach (var assembly in assemblies)
        {
            if (assembly == null)
                continue;

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttribute<ExportAttribute>();

                if (attribute == null)
                    continue;

                switch (attribute.Lifetime)
                {
                    case Lifetime.Singleton:
                        services.AddSingleton(attribute.ContractType, type);
                        break;

                    case Lifetime.Scoped:
                        services.AddScoped(attribute.ContractType, type);
                        break;

                    default:
                        services.AddTransient(attribute.ContractType, type);
                        break;
                }
            }
        }
    }
}