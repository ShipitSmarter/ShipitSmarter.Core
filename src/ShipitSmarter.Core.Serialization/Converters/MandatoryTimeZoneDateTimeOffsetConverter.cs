using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ShipitSmarter.Core.Serialization.Converters;

/// <summary>
/// Custom JsonConverter to enforce time zone specification for DateTimeOffset
/// </summary>
public class MandatoryTimeZoneDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
    /// <summary>
    /// Throws an exception if the DateTimeOffset has no time zone specification
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="JsonException"></exception>
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateTime = DateTime.Parse(reader.GetString()!, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
        if (dateTime.Kind != DateTimeKind.Utc)
        {
            throw new JsonException("Time zone specification for DateTimeOffset is mandatory");
        }
        var dateTimeOffset = DateTimeOffset.Parse(reader.GetString()!, CultureInfo.InvariantCulture);
        
        return dateTimeOffset;
    }

    /// <summary>
    /// Default implementation
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value);
    }
}