namespace ShipitSmarter.Core.Enumerations.Shipment.v1;

/// <summary>
/// Code that indicates how the collection/pickup of the return at the customer should be handled
/// </summary>
public enum PickupPolicy
{
    /// <summary>
    ///  Customer arranges pickup and print/attach label (UPS-PRL).
    /// </summary>
    PRL,

    /// <summary>
    /// 3 Pickup attempts, carrier provides label (UPS-RS3)
    /// </summary>
    FIXED,

    /// <summary>
    /// 1 picking attempt, carrier provides label (UPS-RS1)
    /// </summary>
    ONE,

    /// <summary>
    /// carrier print/attach label on selected box - One pickup attempt (UPS-PAC)
    /// </summary>
    PAC1,

    /// <summary>
    ///  carrier print/attach label on selected box - Three pickup attempts
    /// </summary>
    PAC3,

    /// <summary>
    /// Carrier exchanges product for another product that carrier directly brings with collecting the return
    /// </summary>
    EXCHANGE,

    /// <summary>
    /// Customer can return its shipment to a service point of the carrier
    /// </summary>
    SERVICEPOINT,
    
    /// <summary>
    /// Carrier e-mails an electronic return label or a link to a label
    /// </summary>
    ERL,
}
