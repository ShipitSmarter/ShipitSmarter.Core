namespace ShipitSmarter.Core;

/// <summary>
/// Helper to set and read the current correlation id for logging
/// </summary>
public interface ICorrelator
{
    /// <summary>
    /// Set the correlation id for the scoped context
    /// </summary>
    /// <param name="correlationId"></param>
    void SetCorrelationId(Guid correlationId);
    
    /// <summary>
    /// Current correlation id of this scope.
    /// </summary>
    Guid CurrentCorrelationId { get; }
}