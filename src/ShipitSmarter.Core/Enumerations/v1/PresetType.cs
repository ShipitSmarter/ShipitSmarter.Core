namespace ShipitSmarter.Core.Enumerations.v1;

/// <summary>
/// Defines the type of preset. This is used during Json Deserialization to discriminate between the type
/// </summary>
public enum PresetType
{
    /// <summary>
    /// Preset package type
    /// </summary>
    PackageType,
    
    /// <summary>
    /// Time slot for pickup
    /// </summary>
    TimeSlotPickup
}