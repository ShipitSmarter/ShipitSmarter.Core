using ShipitSmarter.Core.DataAnnotations;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core.Models.v1;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class Address()
{
    public string? CompanyName { get; set; }
    [RequiredNotDefault]
    public string AddressLine1 { get; set; } = Defaults.String;
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? StreetNumber { get; set; }
    public string? City { get; set; }
    public string? StateCode { get; set; }
    public string? PostCode { get; set; }
    [RequiredNotDefault]
    public CountryCode CountryCode { get; set; } = Defaults.CountryCode;
    public string? Vat { get; set; }
    public string? Eori { get; set; }
    public string? ContactName { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public List<AddressAccount>? Accounts { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
