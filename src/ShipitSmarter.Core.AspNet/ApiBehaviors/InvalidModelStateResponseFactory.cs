using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ShipitSmarter.Core.AspNet.ApiBehaviors;


/// <summary>
/// Configures the model state response to return our ProblemDetails with custom fields.
/// <code>
///     services.AddControllers().ConfigureApiBehaviorOptions(options =>
///     {
///         options.InvalidModelStateResponseFactory = ShipitSmarter.Core.ApiBehaviors.InvalidModelStateResponseFactory.CreateValidationResponse;
///     });
/// </code> 
/// </summary>
public static class InvalidModelStateResponseFactory
{
    /// <summary>
    /// Creates a json response containing the <see cref="ValidationProblemDetails"/>
    /// </summary>
    public static IActionResult CreateValidationResponse(ActionContext context)
    {
        var correlator = context.HttpContext.RequestServices.GetRequiredService<ICorrelator>();
        var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
            }
            .WithType()
            .WithPath(context.HttpContext.Request.Path)
            .WithCorrelation(correlator);
        
        problemDetails.Extensions["correlationId"] = correlator.CurrentCorrelationId.ToString();
            
        var result = new BadRequestObjectResult(problemDetails);
        result.ContentTypes.Add("application/problem+json");

        return result;
    }
}