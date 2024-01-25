using ShipitSmarter.Core.Enumerations.HandlingUnit.v1;
using ShipitSmarter.Core.Enumerations.v1;

namespace ShipitSmarter.Core;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class Defaults
{
    public const int Int = int.MinValue;
    public const decimal Decimal = decimal.MinValue;
    public const int Enum = int.MinValue;
    public static readonly DateTime DateTime = new(1900, 1, 1);
    public static readonly DateTimeOffset DateTimeOffset = new(1900, 1, 1, 0, 0, 0, TimeSpan.Zero);
    public const string String = "";

    public const string SmartEnumDefault = "DEFAULT";
    public static readonly CountryCode CountryCode = CountryCode.DEFAULT;
    public static readonly CurrencyCode CurrencyCode = CurrencyCode.DEFAULT;
    public static readonly PackageType PackageType = PackageType.DEFAULT;
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member