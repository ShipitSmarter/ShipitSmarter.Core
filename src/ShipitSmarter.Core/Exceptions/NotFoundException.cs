namespace ShipitSmarter.Core.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(string id, Type type) : base($"{type.Name} {id} not found.")
    {
        StatusCode = 404;
    }

    public static NotFoundException ForType<T>(string friendlyId) => new(friendlyId, typeof(T));
}