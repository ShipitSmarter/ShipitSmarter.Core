using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShipitSmarter.Core.Models.v1;

namespace ShipitSmarter.Core.AspNet.Implementations;

/// <summary>
/// ExceptionHandler that will return a ProblemDetails response
/// </summary>
public class CoreExceptionHandler
{
    /// <summary>
    /// Handles the exception and returns a ProblemDetails response 
    /// </summary>
    public static Task Handle(HttpContext context, ProblemDetailsWrapper wrapper)
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>()!;
        var correlator = context.RequestServices.GetRequiredService<ICorrelator>();
        var logger = context.RequestServices.GetRequiredService<ILogger<CoreExceptionHandler>>();
        
        var exception = exceptionHandlerFeature.Error;
        var problem = WrapException(logger, exception, wrapper)
            .WithType()
            .WithPath(exceptionHandlerFeature.Path)
            .WithCorrelation(correlator);

        context.Response.StatusCode = problem.Status ?? 500;
        context.Response.WriteAsJsonAsync(problem);
        
        return Task.CompletedTask;
    }
    
    private static CoreProblemDetails WrapException(ILogger logger, Exception exception, ProblemDetailsWrapper wrapper)
    {
        logger.LogError(exception, exception.Message);
        try
        {
            return wrapper.Wrap(exception);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Wrapping Exception failed");
            return ProblemDetailsWrapper.Default();
        }
    }
}