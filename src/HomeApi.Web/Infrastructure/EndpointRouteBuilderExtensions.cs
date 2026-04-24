using System.Diagnostics.CodeAnalysis;

namespace HomeApi.Web.Infrastructure;

public static class EndpointRouteBuilderExtensions
{
    public static RouteHandlerBuilder MapGet<TResponse>(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapGet(pattern, handler)
            .Produces<TResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName(handler.Method.Name);
    }

    public static RouteHandlerBuilder MapPost<TRequest, TResponse>(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern = "")
        where  TRequest : notnull
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapPost(pattern, handler)
            .Accepts<TRequest>("application/json")
            .Produces<TResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName(handler.Method.Name);
    }

    public static RouteHandlerBuilder MapPut<TResponse>(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern)
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapPut(pattern, handler)
            .Produces<TResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .WithName(handler.Method.Name);
    }

    public static RouteHandlerBuilder MapDelete<TRequest, TResponse>(this IEndpointRouteBuilder builder, Delegate handler, [StringSyntax("Route")] string pattern)
        where TRequest : notnull
    {
        Guard.Against.AnonymousMethod(handler);

        return builder.MapDelete(pattern, handler)
            .Accepts<TRequest>("application/json")
            .Produces<TResponse>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .WithName(handler.Method.Name);
    }
}
