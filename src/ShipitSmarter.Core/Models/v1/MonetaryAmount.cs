using ShipitSmarter.Core.DataAnnotations;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Defines a monetary amount in a given currency
/// </summary>
public class MonetaryAmount
{
    /// <summary>
    /// The value of the monetary amount in the given currency
    /// </summary>
    [RequiredNotDefault]
    public decimal Value { get; set; } = Defaults.Decimal;

    /// <summary>
    /// The currency code
    /// </summary>
    [RequiredNotDefault]
    public CurrencyCode CurrencyCode { get; set; } = Defaults.CurrencyCode;
}
