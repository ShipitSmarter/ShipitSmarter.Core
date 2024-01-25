namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Relation type of account
/// </summary>
public enum ShipmentRelationType
{
    /// <summary>
    /// Sender of shipment
    /// </summary>
    Sender,
    /// <summary>
    /// Receiver of shipment
    /// </summary>
    Receiver,
    /// <summary>
    /// Third party involved with shipment
    /// </summary>
    ThirdParty,
    /// <summary>
    /// Any duties and taxes associated with shipment
    /// </summary>
    DutiesAndTaxes,
}
