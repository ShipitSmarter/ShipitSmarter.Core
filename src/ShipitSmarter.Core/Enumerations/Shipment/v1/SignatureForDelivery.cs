namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Signature delivery options
/// </summary>
[Serializable]
public enum SignatureForDelivery
{
    /// <summary>
    /// No requirement on signature
    /// </summary>
    [Obsolete]
    None,
    /// <summary>
    /// Signature of person where shipment is addressed to (Y)
    /// </summary>
    ConsigneeOnly,
    /// <summary>
    /// Indirect signature (I), of anybody who can sign for receiving the shipment
    /// </summary>
    Indirect,
    /// <summary>
    /// Adult signature only (A)
    /// </summary>
    Adult,
    /// <summary>
    /// No signature required (false)
    /// </summary>
    NoSignatureRequired,
}
