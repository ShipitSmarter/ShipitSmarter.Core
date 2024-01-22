using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Defines a monetary amount in a given currency
/// </summary>
public class MonetaryAmount(decimal value, CurrencyCode currencyCode)
{
    /// <summary>
    /// The value of the monetary amount in the given currency
    /// </summary>
    [Required]
    public decimal Value { get; set; } = value;

    /// <summary>
    /// The currency code
    /// </summary>
    [Required]
    public CurrencyCode CurrencyCode { get; set; } = currencyCode;
}
