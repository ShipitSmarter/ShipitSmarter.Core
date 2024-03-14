namespace ShipitSmarter.Core.DataAnnotations;

/// <summary>
/// Validates that this value is greater than or equal the value of another property.
/// </summary>
public class GreaterThanOrEqualAttribute : PropertyComparerAttribute
{
    /// <inheritdoc/>
    public GreaterThanOrEqualAttribute(string dependentProperty) : base(Operator.GreaterThanOrEqualTo, dependentProperty)
    { }
}
