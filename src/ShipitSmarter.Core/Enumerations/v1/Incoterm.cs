namespace ShipitSmarter.Core.Enumerations.v1;

/// <summary>
/// The 3 digit Incoterm codes as per incoterms 2010 and 2020
/// </summary>
public enum Incoterm
{
    /// <summary>
    /// Ex Works (named place of delivery)
    /// </summary>
    EXW,

    /// <summary>
    /// FCA – Free Carrier (named place of delivery)
    /// </summary>
    FCA,

    /// <summary>
    /// Carriage Paid To (named place of destination)
    /// </summary>
    CPT,

    /// <summary>
    /// Carriage and Insurance Paid to (named place of destination)
    /// </summary>
    CIP,

    /// <summary>
    /// Delivered At Terminal (named terminal at port or place of destination, replaced by DPU in incoterms 2020)
    /// </summary>
    DAT, 

    /// <summary>
    /// Delivered At Place (named place of destination)
    /// </summary>
    DAP,

    /// <summary>
    /// Delivered Duty Paid (named place of destination)
    /// </summary>
    DDP,

    /// <summary>
    /// Delivered Duty Unpaid (incoterm deprecated in 2010, left for compatibility)
    /// </summary>
    DDU,

    /// <summary>
    /// Cost, Insurance and Freight (named port of destination)
    /// </summary>
    CIF,

    /// <summary>
    /// Free on Board (named port of shipment)
    /// </summary>
    FOB,

    /// <summary>
    /// Delivered at place unloaded (replaces DAT in the new incoterm 2020)
    /// </summary>
    DPU,

    /// <summary>
    /// Free alongside ship
    /// </summary>
    FAS,

    /// <summary>
    /// Cost and freight
    /// </summary>
    CFR,
}
