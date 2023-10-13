using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShipitSmarter.Core.Converters;

/// <summary>
/// Custom JsonConverter to prevent time zone specification for DateTime
/// </summary>
public class NoTimeZoneAllowedDateTimeConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// Throws an exception if the DateTime has a time zone specification
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="JsonException"></exception>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        
        var dateTime = DateTime.Parse(reader.GetString()!, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
        if (dateTime.Kind == DateTimeKind.Utc)
        {
            throw new JsonException("Time zone specification for DateTime is not allowed");
        }

        return dateTime;
    }

    /// <summary>
    /// Default implementation
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value);
    }
}