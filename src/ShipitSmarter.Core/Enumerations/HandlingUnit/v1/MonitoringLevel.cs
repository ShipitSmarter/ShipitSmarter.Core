namespace ShipitSmarter.Core.Enumerations.HandlingUnit.v1;

/// <summary>
/// Special service where the carrier applies additional monitoring to the handling unit
/// </summary>
public enum MonitoringLevel
{
    /// <summary>
    /// The carrier monitors the complete journey of the handling unit (from pickup to delivery) through all modes of transport
    /// </summary>
    CompleteJourney,

    /// <summary>
    /// The carrier monitors the Air part of the journey
    /// </summary>
    Air,

    /// <summary>
    /// The carrier monitors the Road/Ground part of the journey
    /// </summary>
    Road,
}
