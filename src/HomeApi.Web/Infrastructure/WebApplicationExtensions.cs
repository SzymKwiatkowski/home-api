using System.Reflection;
using Minerals.StringCases;

namespace HomeApi.Web.Infrastructure;

public static class WebApplicationExtensions
{
    public static IEndpointRouteBuilder MapGroup(this WebApplication app, EndpointGroupBase group)
    {
        var groupName = group.GetType().Name.ToLower();

        return app
            .MapGroup($"/api/{groupName}")
            // .WithGroupName(groupName.ToPascalCase())
            .WithTags(groupName.ToPascalCase());
    }

    public static WebApplication MapEndpoints(this WebApplication app, Assembly assembly)
    {
        var endpointGroupType = typeof(EndpointGroupBase);

        var endpointGroupTypes = assembly.GetExportedTypes()
            .Where(t => t.IsSubclassOf(endpointGroupType));

        foreach (var type in endpointGroupTypes)
        {
            if (Activator.CreateInstance(type) is EndpointGroupBase instance)
            {
                instance.Map(app);
            }
        }

        return app;
    }
}
