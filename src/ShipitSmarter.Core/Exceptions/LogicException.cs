namespace ShipitSmarter.Core.Exceptions;

public class LogicException : DomainException
{
    public LogicException(string message) : base(message)
    {
        StatusCode = 400;
    }
}