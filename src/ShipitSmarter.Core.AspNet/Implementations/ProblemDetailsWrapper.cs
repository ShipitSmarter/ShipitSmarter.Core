using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShipitSmarter.Core.Exceptions;
using ShipitSmarter.Core.Models.v1;

namespace ShipitSmarter.Core.AspNet.Implementations;

/// <summary>
/// Factory to wrap a an exception into a <see cref="CoreProblemDetails"/>
/// </summary>
// ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
public class ProblemDetailsWrapper
{
    /// <summary>
    /// Default ProblemDetails for exceptions that is not mapped
    /// </summary>
    public static CoreProblemDetails Default() => new()
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
    /// <remarks>
    /// When inheriting this class and overriding this method, always have a fallback that calls base.Wrap(exception).
    /// </remarks>
    public virtual CoreProblemDetails Wrap(Exception exception)
    {
        return exception switch
        {
            DomainException domainException => WrapInProblemDetails(domainException),
            _ => Default()
        };
    }

    private static CoreProblemDetails WrapInProblemDetails(DomainException domainException)
    {
        var problemDetails = new CoreProblemDetails
        {
            Title = domainException.Title,
            Detail = domainException.Detail,
            Status = domainException.StatusCode,
            Errors = domainException.Errors
        };
        return problemDetails;
    }
}
