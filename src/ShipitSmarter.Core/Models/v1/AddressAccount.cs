using ShipitSmarter.Core.DataAnnotations;

namespace ShipitSmarter.Core.Models.v1;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class AddressAccount
{
    public string? Label { get; set; }
    [RequiredNotDefault]
    public string CarrierReference { get; set; } = Defaults.String;
    public string? AccountNumber { get; set; }
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
