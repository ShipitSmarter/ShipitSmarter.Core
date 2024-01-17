
using ShipitSmarter.Core;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Mvc;

/// <summary>
/// Extensions for <see cref="ProblemDetails"/>
/// </summary>
public static class ProblemDetailsExtensions
{
    /// <summary>
    /// Set's the instance to the path provided
    /// </summary>
    public static ProblemDetails WithPath(this ProblemDetails problem, string path)
    {
        problem.Instance = path;
        return problem;
    }
    
    /// <summary>
    /// Set's type to https://httpstatuses.io/{problem.Status} if not already set.
    /// </summary>
    public static ProblemDetails WithType(this ProblemDetails problem)
    {
        problem.Type ??= $"https://httpstatuses.io/{problem.Status ?? 500}";
        return problem;
    }
    
    /// <summary>
    /// Add the current correlation id
    /// </summary>
    public static ProblemDetails WithCorrelation(this ProblemDetails problem, ICorrelator correlator)
    {
        problem.Extensions["correlationId"] = correlator.CurrentCorrelationId.ToString();
        return problem;
    }
}