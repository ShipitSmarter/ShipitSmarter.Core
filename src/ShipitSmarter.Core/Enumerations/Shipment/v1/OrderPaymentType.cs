namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Type indicating how the order is paid by the Customer
/// </summary>
public enum OrderPaymentType
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    CreditCard,
    CashOnDelivery,
    AccountsReceivable,
    AccountsReceivableIntercompany,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
