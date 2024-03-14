using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ShipitSmarter.Core.DataAnnotations;

/// <summary>
/// Base class for attributes that compare to a value of another property.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class PropertyComparerAttribute : ValidationAttribute
{
    private readonly string _dependentProperty;
    private readonly OperatorValidator _validator;

    /// <inheritdoc/>
    public PropertyComparerAttribute(Operator @operator, string dependentProperty)
    {
        _dependentProperty = dependentProperty;
        _validator = OperatorValidator.Operators[@operator];
    }

    /// <inheritdoc/>
    public override bool RequiresValidationContext => true;

    /// <inheritdoc/>
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var dependentPropertyInfo = validationContext.ObjectType.GetProperty(_dependentProperty);
        if (dependentPropertyInfo is null) {
            return new ValidationResult(string.Format(CultureInfo.CurrentCulture, "The type '{0}' does not contain a public property named '{1}'.", validationContext.ObjectType, _dependentProperty));
        }

        var dependentValue = dependentPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (!_validator.IsValid(value, dependentValue)) {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        return ValidationResult.Success;
    }

    private string DefaultErrorMessage => $"{{0}} must be {_validator.ErrorMessage} {{1}}.";

    /// <inheritdoc/>
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessageResourceName) && string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = DefaultErrorMessage;
        }

        return string.Format(ErrorMessageString, name, _dependentProperty);
    }
}
