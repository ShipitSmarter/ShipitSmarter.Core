using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using ShipitSmarter.Core.Exceptions;
using ShipitSmarter.Core.Models.v1;

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
    /// Creates a json response containing the <see cref="CoreProblemDetails"/>
    /// </summary>
    public static IActionResult CreateValidationResponse(ActionContext context)
    {
        var correlator = context.HttpContext.RequestServices.GetRequiredService<ICorrelator>();
        var problemDetails = new CoreProblemDetails()
            {
                Title = "One or more Json deserialization errors occurred.",
                Status = StatusCodes.Status400BadRequest,
            }
            .WithType()
            .WithPath(context.HttpContext.Request.Path)
            .WithCorrelation(correlator);
        
        problemDetails.Errors = CreateErrorList(context.ModelState);
            
        var result = new BadRequestObjectResult(problemDetails);
        result.ContentTypes.Add("application/problem+json");

        return result;
    }

    private static List<Error> CreateErrorList(ModelStateDictionary modelState)
    {
        ArgumentNullException.ThrowIfNull(modelState, nameof (modelState));
        var errorList = new List<Error>();
        foreach (var keyValuePair in modelState)
        {
            var errors = keyValuePair.Value.Errors;
            if (errors.Count == 0)
            {
                continue;
            }
            
            var errorMessages = errors.Select(GetErrorMessage);
            errorList.Add(new Error()
            {
                Code = "JsonDeserializationError",
                Message = $"{keyValuePair.Key}: {string.Join(";", errorMessages)}"
            });
        }

        return errorList;
        
        static string GetErrorMessage(ModelError error)
        {
            return !string.IsNullOrEmpty(error.ErrorMessage) ? error.ErrorMessage : "The input was not valid";
        }
    }
}