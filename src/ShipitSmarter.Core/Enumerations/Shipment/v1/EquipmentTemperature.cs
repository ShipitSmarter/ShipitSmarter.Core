namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Describes the temperature under which the shipment should be transported in case of temperature sensitive goods.
/// </summary>
public enum EquipmentTemperature
{
    /// <summary>
    /// Ambient: +15 to +25 Celsius
    /// </summary>
    Ambient,

    /// <summary>
    /// Cooled: +2 to +8 Celsius
    /// </summary>
    Cooled,

    /// <summary>
    /// Frozen: -18 Celsius
    /// </summary>
    Frozen,

    /// <summary>
    /// Dry Ice: -80 Celsius
    /// </summary>
    DryIceReplenishment,

    /// <summary>
    /// Cryo: -150 Celsius
    /// </summary>
    Cryo,
}
