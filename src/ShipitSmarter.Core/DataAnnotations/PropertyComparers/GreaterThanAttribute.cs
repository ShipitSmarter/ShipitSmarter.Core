namespace ShipitSmarter.Core.DataAnnotations;

/// <summary>
/// Validates that this value is greater than the value of another property.
/// </summary>
public class GreaterThanAttribute : PropertyComparerAttribute
{
    /// <inheritdoc/>
    public GreaterThanAttribute(string dependentProperty) : base(Operator.GreaterThan, dependentProperty)
    { }
}
