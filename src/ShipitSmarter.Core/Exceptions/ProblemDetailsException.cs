using ShipitSmarter.Core.Models.v1;

namespace ShipitSmarter.Core.Exceptions;

/// <summary>
/// Default exception when a CoreProblemDetails is returned
/// </summary>
public class ProblemDetailsException: DomainException
{
    
    /// <summary>
    /// Instantiates a new instance of a <exception cref="ProblemDetailsException"></exception>
    /// </summary>
    /// <param name="problemDetails">The problem details to be used</param>
    /// <param name="message">(Optional) The message that describes the error.</param>
    public ProblemDetailsException(CoreProblemDetails problemDetails, string? message = null) 
        : base(message ?? problemDetails.Title ?? "An error occurred")
    {
        Detail = problemDetails.Detail;
        StatusCode = problemDetails.Status ?? 500;
        
        foreach (var error in problemDetails.Errors)
        {
            Errors.Add(error);
        }
    }
}