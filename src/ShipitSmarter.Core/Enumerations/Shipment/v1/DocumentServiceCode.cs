namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Code indicating how the document shall be delivered to the forwarder
/// </summary>
public enum DocumentServiceCode
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Original,
    House,
    Telex,
    ForwardsCargoReceipt,
    Pickup,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
