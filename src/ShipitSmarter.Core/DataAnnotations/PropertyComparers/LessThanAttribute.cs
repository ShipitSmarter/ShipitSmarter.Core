namespace ShipitSmarter.Core.DataAnnotations;

/// <summary>
/// Validates that this value is less than the value of another property.
/// </summary>
public class LessThanAttribute : PropertyComparerAttribute
{
    /// <inheritdoc/>
    public LessThanAttribute(string dependentProperty) : base(Operator.LessThan, dependentProperty)
    { }
}
