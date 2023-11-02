using System.Globalization;

namespace ShipitSmarter.Core.Helpers;

/// <summary>
/// Helpers for converting DateTime to string and vice versa
/// </summary>
public static class DateTimeHelpers
{
    /// <summary>
    /// Convert nullable string to nullable DateTime
    /// </summary>
    /// <param name="value">nullable datetime string</param>
    /// <returns>Nullable DateTime object</returns>
    public static DateTime? ToNullableDateTime(this string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.ToDateTime();
    }

    /// <summary>
    /// Convert string to DateTime
    /// </summary>
    /// <param name="value">datetime string</param>
    /// <returns>DateTime object</returns>
    public static DateTime ToDateTime(this string value)
    {
        return DateTime.Parse(value);
    }

    /// <summary>
    /// Convert nullable DateTime to nullable string
    /// </summary>
    /// <param name="value">Nullable DateTime object</param>
    /// <returns>Nullable ISO 8601 compliant string representation</returns>
    public static string? ToNullableIso8601(this DateTime? value)
    {
        return value?.ToIso8601();
    }

    /// <summary>
    /// Convert DateTime to string
    /// </summary>
    /// <param name="value">DateTime object</param>
    /// <returns>ISO 8601 compliant string representation</returns>
    public static string ToIso8601(this DateTime value)
    {
        return value.ToString("O", CultureInfo.InvariantCulture);
    }
}