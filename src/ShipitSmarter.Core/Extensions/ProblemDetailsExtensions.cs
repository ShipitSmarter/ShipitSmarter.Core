// ReSharper disable once CheckNamespace
namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Extensions for <see cref="CoreProblemDetails"/>
/// </summary>
public static class ProblemDetailsExtensions
{
    /// <summary>
    /// Set's the instance to the path provided
    /// </summary>
    public static CoreProblemDetails WithPath(this CoreProblemDetails coreProblem, string path)
    {
        coreProblem.Instance = path;
        return coreProblem;
    }
    
    /// <summary>
    /// Set's type to https://httpstatuses.io/{problem.Status} if not already set.
    /// </summary>
    public static CoreProblemDetails WithType(this CoreProblemDetails coreProblem)
    {
        coreProblem.Type ??= $"https://httpstatuses.io/{coreProblem.Status ?? 500}";
        return coreProblem;
    }
    
    /// <summary>
    /// Add the current correlation id
    /// </summary>
    public static CoreProblemDetails WithCorrelation(this CoreProblemDetails coreProblem, ICorrelator correlator)
    {
        coreProblem.CorrelationId = correlator.CurrentCorrelationId;
        return coreProblem;
    }
}