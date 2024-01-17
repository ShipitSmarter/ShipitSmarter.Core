namespace ShipitSmarter.Core.Exceptions;

/// <summary>
/// An exception that can be used when something conflicts with the current state of things
/// E.G. cannot cancel shipment if currently being ordered
/// </summary>
public class ConflictException : DomainException
{
    /// <summary>
    /// Initializes a new instance of the <exception cref="ConflictException"></exception> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public ConflictException(string message) : base(message)
    {
        StatusCode = 409; // StatusCodes.Status409Conflict;
    }
}