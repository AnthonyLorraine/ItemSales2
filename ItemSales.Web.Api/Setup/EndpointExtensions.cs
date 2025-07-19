using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ItemSales.Web.Api.Setup;

/// <summary>
/// Implemented using this guide to auto register minimal API's
/// <seealso href="https://www.milanjovanovic.tech/blog/automatically-register-minimal-apis-in-aspnetcore"/>
/// </summary>
public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var endpointDescriptors = assembly.DefinedTypes
            .Where(t => 
                t is { IsAbstract: false, IsInterface: false } && 
                t.IsAssignableTo(typeof(IEndpoint)))
            .Select(t => 
                ServiceDescriptor.Transient(typeof(IEndpoint), t))
            .ToArray();
        
        services.TryAddEnumerable(endpointDescriptors);
        
        return services;
    }

    public static IApplicationBuilder MapEndpoints(this WebApplication app, RouteGroupBuilder? group)
    {
        var endpoints = app.Services.GetRequiredService<IEnumerable<IEndpoint>>();

        IEndpointRouteBuilder builder = group is null ? app : group;
        
        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoint(builder);
        }

        return app;
    }
}