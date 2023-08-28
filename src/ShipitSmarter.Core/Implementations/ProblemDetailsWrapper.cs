using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipitSmarter.Core.Exceptions;

namespace ShipitSmarter.Core.Implementations;

/// <summary>
/// Factory to wrap a an exception into a <see cref="ProblemDetails"/>
/// </summary>
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class ProblemDetailsWrapper
{
    /// <summary>
    /// Default ProblemDetails for exceptions that is not mapped
    /// </summary>
    public static ProblemDetails Default() => new()
    {
        Title = "Something unexpected happened",
        Status = StatusCodes.Status500InternalServerError
    };

    /// <summary>
    /// Wrap the exception into a ProblemDetails object
    /// Note: following fields are added automatically <see cref="CoreExceptionHandler.Handle"/>
    ///   - CorrelationId
    ///   - Type (based on status code)
    ///   - Instance (based on request path) 
    /// </summary>
    public virtual ProblemDetails Wrap(Exception exception)
    {
        return exception switch
        {
            DomainException domainException => WrapInProblemDetails(domainException),
            _ => Default()
        };
    }

    private static ProblemDetails WrapInProblemDetails(DomainException domainException)
    {
        var problemDetails = new ProblemDetails
        {
            Title = domainException.Title,
            Detail = domainException.Detail,
            Status = domainException.StatusCode
        };
        foreach (var kv in domainException.Extensions)
        {
            problemDetails.Extensions.Add(kv.Key, kv.Value);
        }

        return problemDetails;
    }
}
