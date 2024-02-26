namespace ShipitSmarter.Core;

/// <summary>
/// DateTime resolver
/// </summary>
public interface IDateTimeResolver
{
    /// <summary>
    /// Holds the current Date and Time
    /// </summary>
    DateTime Now { get; }
    
    /// <summary>
    /// Holds the current Date
    /// </summary>
    DateTime Today { get; }
}