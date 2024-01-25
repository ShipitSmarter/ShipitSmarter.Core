namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Specifies how the Cash on delivery is monetized
/// </summary>
public enum CashOnDeliveryType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    Cash,
    Cheque,
    Draft,
    MoneyOrder,
    CashierCheque,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
