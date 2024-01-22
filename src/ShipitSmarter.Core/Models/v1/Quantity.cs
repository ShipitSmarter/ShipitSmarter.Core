using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// A quantity measured in the specified unit.
/// </summary>
public class Quantity(decimal value, QuantityUnitOfMeasure unitOfMeasure)
{
    /// <summary>
    /// The quantity
    /// </summary>
    [Required]
    public decimal Value { get; set; } = value;

    /// <summary>
    /// The unit of measure
    /// </summary>
    [Required]
    public QuantityUnitOfMeasure UnitOfMeasure { get; set; } = unitOfMeasure;
}
