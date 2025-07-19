using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ItemSales.Web.Api.Setup;

public class Server500ProblemExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsService _problemDetailsService;
    
    public Server500ProblemExceptionHandler(IProblemDetailsService problemDetailsService)
    {
        _problemDetailsService = problemDetailsService;
    }
    
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (httpContext.Response.StatusCode != StatusCodes.Status500InternalServerError)
        {
            return true;
            
        }
        
        var problem = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            AdditionalMetadata = null,
            ProblemDetails = new ProblemDetails()
            {
                Type = exception.GetType().Name,
                Title = "An error occured",
                Detail = exception.Message
            },
            Exception = exception
        };
        return await _problemDetailsService.TryWriteAsync(problem);
    }
}