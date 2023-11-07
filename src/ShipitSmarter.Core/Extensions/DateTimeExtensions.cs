namespace ShipitSmarter.Core.Extensions;

/// <summary>
/// Extension methods to convert DateTime with Unspecified timezone to UTC and back
/// Used to convert (unspecified) DateTime from/to Mongo DB, since mongo auto-converts to UTC
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Convert Nullable Local or Unspecified DateTime to nullable UTC
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime? ToUtcNullable(this DateTime? dateTime)
    {
        return dateTime?.ToUtc();
    }

    /// <summary>
    /// Convert Local or Unspecified DateTime to UTC
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToUtc(this DateTime dateTime)
    {
        return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }

    /// <summary>
    /// Convert nullable UTC DateTime to nullable Unspecified DateTime
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime? ToUnspecifiedNullable(this DateTime? dateTime)
    {
        return dateTime?.ToUnspecified();
    }

    /// <summary>
    /// Convert UTC DateTime to Unspecified DateTime
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime ToUnspecified(this DateTime dateTime)
    {
        return DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
    }
}