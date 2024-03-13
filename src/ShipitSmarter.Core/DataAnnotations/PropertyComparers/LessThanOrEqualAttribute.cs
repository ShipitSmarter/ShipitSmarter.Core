namespace ShipitSmarter.Core.DataAnnotations;

/// <summary>
/// Validates that this value is less than or equal to the value of another property.
/// </summary>
public class LessThanOrEqualAttribute : PropertyComparerAttribute
{
    /// <inheritdoc/>
    public LessThanOrEqualAttribute(string dependentProperty) : base(Operator.LessThanOrEqualTo, dependentProperty)
    { }
}
