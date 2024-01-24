using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Attributes;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// A quantity measured in the specified unit.
/// </summary>
public class Quantity()
{
    /// <summary>
    /// The quantity
    /// </summary>
    [RequiredNotDefault]
    public decimal Value { get; set; } = Defaults.Decimal;

    /// <summary>
    /// The unit of measure
    /// </summary>
    [RequiredNotDefault]
    public QuantityUnitOfMeasure UnitOfMeasure { get; set; } = (QuantityUnitOfMeasure)Defaults.Enum;
}
