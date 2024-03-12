namespace ShipitSmarter.Core.Enumerations.v1;

/// <summary>
/// Defines the type of preset. This is used during Json Deserialization to discriminate between the type
/// </summary>
public enum FlexibleConfigType
{
    /// <summary>
    /// Preset package type
    /// </summary>
    Preset_PackageType,
    
    /// <summary>
    /// Time slot for pickup
    /// </summary>
    Preset_TimeSlot,
    
    /// <summary>
    /// Shipment create page settings
    /// </summary>
    Setting_ShipmentCreatePage
}