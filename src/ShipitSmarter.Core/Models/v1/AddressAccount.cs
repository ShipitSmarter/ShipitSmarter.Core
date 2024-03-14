using ShipitSmarter.Core.DataAnnotations;

namespace ShipitSmarter.Core.Models.v1;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class AddressAccount
{
    [RequiredNotDefault]
    public string? Label { get; set; } = Defaults.String;
    [RequiredNotDefault]
    public string CarrierReference { get; set; } = Defaults.String;
    [RequiredNotDefault]
    public string? AccountNumber { get; set; } = Defaults.String;
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
