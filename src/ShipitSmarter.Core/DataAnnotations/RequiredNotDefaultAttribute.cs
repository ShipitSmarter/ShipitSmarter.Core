using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Enumerations.HandlingUnit.v1;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core.DataAnnotations;

/// <inheritdoc cref="RequiredAttribute"/>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
public class RequiredNotDefaultAttribute : RequiredAttribute
{
    /// <inheritdoc cref="IsValid"/>
    public override bool IsValid(object? value)
    {
        return value switch
        {
            null => false,
            Defaults.String => false,
            Defaults.Decimal => false,
            Defaults.Int => false,
            CountryCode countryCode when countryCode == Defaults.CountryCode => false,
            CurrencyCode currencyCode when currencyCode == Defaults.CurrencyCode => false,
            PackageType packageType when packageType == Defaults.PackageType => false,
            DateTime dateTime when dateTime == Defaults.DateTime => false,
            DateTimeOffset dateTimeOffset when dateTimeOffset == Defaults.DateTimeOffset => false,
            Enum @enum when Convert.ToInt32(@enum) == Defaults.Enum => false,
            _ => base.IsValid(value)
        };
    }
}