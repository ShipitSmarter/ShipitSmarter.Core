namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Classifies the shipment on how it is regulated. If multiple regulations apply, take the highest regulated type
/// </summary>
public enum DangerousGoodsType
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
{
    ExceptedQuantity,
    LimitedQuantity,
    LithiumBatteries,
    DryIce,
    PassengerAircraftOk,
    CargoAircraftOnly,
    RadioActiveMaterial,
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
