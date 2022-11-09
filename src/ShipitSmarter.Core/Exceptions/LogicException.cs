namespace ShipitSmarter.Core.Exceptions;

/// <summary>
/// An exception that can be used when something doesn't make sense from a business perspective
/// E.G.  Cannot ship to address that does not exist
/// </summary>
public class LogicException : DomainException
{
    /// <summary>Initializes a new instance of the <exception cref="LogicException"></exception> class with a specified error message.</summary>
    /// <param name="message">The message that describes the error.</param>
    public LogicException(string message) : base(message)
    {
        StatusCode = 400;
    }
}