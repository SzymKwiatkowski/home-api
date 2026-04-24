using System.Reflection;
using HomeApi.Application.Common.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace HomeApi.Infrastructure.Extensions;

public static class AddServiceExtensions
{
    public static IServiceCollection AddScopedServices(this IServiceCollection services)
    {
        var inheritedTypes = GetInheritedInterfaces(typeof(IScopedService));

        foreach (var t in inheritedTypes)
        {
            foreach (var interfaceType in t.InterfaceTypes)
            {
                services.AddScoped(interfaceType, t.ClassType);
            }
        }
        
        return services;
    }
    
    public static IServiceCollection AddTransientServices(this IServiceCollection services)
    {
        var inheritedTypes = GetInheritedInterfaces(typeof(ITransientService));

        foreach (var t in inheritedTypes)
        {
            foreach (var interfaceType in t.InterfaceTypes)
            {
                services.AddTransient(interfaceType, t.ClassType);
            }
        }
        
        return services;
    }
    
    public static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        var inheritedTypes = GetInheritedInterfaces(typeof(ISingletonService));

        foreach (var t in inheritedTypes)
        {
            foreach (var interfaceType in t.InterfaceTypes)
            {
                services.AddSingleton(interfaceType, t.ClassType);
            }
        }
        
        return services;
    }
    
    internal static IEnumerable<(Type ClassType, IEnumerable<Type> InterfaceTypes)> GetInheritedInterfaces(
        Type baseInterfaceType)
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetLoadableTypes())
            .Where(t => t.GetInterfaces().Contains(baseInterfaceType) && !t.IsAbstract && !t.IsInterface)
            .Select(x => (ClassType: x, InterfaceTypes: x.GetInterfaces().Where(x => x != baseInterfaceType)));
            
    }
    
    internal static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException ex)
        {
            var result = ex.Types.Where(t => t != null) ?? [];
            return [];
        }
    }
}
