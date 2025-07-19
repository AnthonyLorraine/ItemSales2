using Microsoft.AspNetCore.Http.Features;

namespace ItemSales.Web.Api.Setup;

public static class CustomProblemDetails
{
    public static IServiceCollection AddCustomProblemDetails(this IServiceCollection services)
    {
        services.AddProblemDetails(o =>
        {
            o.CustomizeProblemDetails = context =>
            {
                context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
                context.ProblemDetails.Extensions.Add("requestId", context.HttpContext.TraceIdentifier);
                var activityFeature= context.HttpContext.Features.Get<IHttpActivityFeature>();
                context.ProblemDetails.Extensions.Add("traceId", activityFeature?.Activity.Id);
            };
        });
        return services;
    }
}