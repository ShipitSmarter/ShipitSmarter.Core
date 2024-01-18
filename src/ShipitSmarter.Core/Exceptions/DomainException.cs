namespace ShipitSmarter.Core.Exceptions;

/// <summary>
/// Base exception class for any domain error.
/// Mimics the "ProblemDetails" class and allows the setting of a status code so that exceptions can bubble up and be handled by middleware
/// </summary>
public abstract class DomainException : Exception
{
    /// <summary>
    /// Status Code that describes the exception
    /// </summary>
    public int StatusCode { get; protected set; } = 500;
    
    /// <summary>
    /// A short, human-readable summary of the problem type.It SHOULD NOT change from occurrence to occurrence
    /// of the problem, except for purposes of localization(e.g., using proactive content negotiation;
    /// see[RFC7231], Section 3.4).
    /// </summary>
    public string Title => Message;
    
    /// <summary>
    /// A human-readable explanation specific to this occurrence of the problem.
    /// </summary>
    public string? Detail { get; protected set; }
    
    /// <inheritdoc cref="Error"/>
    public List<Error> Errors { get; } = new();

    /// <summary>
    /// Instantiates a new instance of a <exception cref="DomainException"></exception>
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    protected DomainException(string message) : base(message)
    {
    }
}

