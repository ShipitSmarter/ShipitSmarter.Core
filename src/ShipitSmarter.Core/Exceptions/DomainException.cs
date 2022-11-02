namespace ShipitSmarter.Core.Exceptions;

public abstract class DomainException : Exception
{
    public int StatusCode { get; protected set; } = 500;
    public string Title => Message;
    public string? Detail { get; protected set; }
    public Dictionary<string, object> Extensions { get; } = new();

    protected DomainException(string message) : base(message)
    {
    }
}