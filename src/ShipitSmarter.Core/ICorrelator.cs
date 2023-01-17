namespace ShipitSmarter.Core;

public interface ICorrelator
{
    void SetCorrelationId(Guid correlationId);
    Guid CurrentCorrelationId { get; }
}