using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace ItemSales.Web.Api.Setup;

public static class Routes
{
    public const string Inventory = "/Inventory";
    public static void ConfigureEndpointRoutes(this WebApplication app)
    {
        var apiVersionSet = app.ConfigureApiVersioning();

        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = HealthCheckHelpers.FormattedHealthCheckResponseWriter
        });

        var apiGroup = app
            .MapGroup("/api/v{version:apiVersion}")
            .WithApiVersionSet(apiVersionSet);

        app.MapEndpoints(apiGroup);
    }
}
