namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Helper to return paginated results
/// </summary>
public interface IPaginated
{
    /// <summary>
    /// Number of items per page
    /// </summary>
    int? PageSize { get; }

    /// <summary>
    /// Page number
    /// </summary>
    int? PageNumber { get; }
}