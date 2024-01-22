using System.Text.Json;
using System.Text.Json.Serialization;
using Ardalis.SmartEnum;

namespace ShipitSmarter.Core.Enumerations;

// Original @ https://github.com/ardalis/SmartEnum/blob/main/src/SmartEnum.SystemTextJson/SmartEnumNameConverter.cs
// Custom because when it can't parse the name it throws an error that's not use able for us.
// Example message "Error converting value '{name}' to a smart enum."

/// <summary>
/// Json converter for <see cref="SmartEnum{TEnum, TValue}"/>
/// </summary>
public class SmartEnumNameConverter<TEnum, TValue> : JsonConverter<TEnum>
    where TEnum : SmartEnum<TEnum, TValue>
    where TValue : IEquatable<TValue>, IComparable<TValue>, IConvertible
{
    /// <summary>
    /// Read Json to <typeparamref name="TEnum"/>
    /// </summary>
    /// <exception cref="JsonException"></exception>
    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return GetFromName(reader.GetString());
        }

        throw new JsonException($"{typeof(TEnum).Name} should be of type String, not: {reader.TokenType}");
    }

    /// <summary>
    /// Write <typeparamref name="TEnum"/> to Json
    /// </summary>
    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Name);
    }

    private static TEnum GetFromName(string? name)
    {
        if (name == null)
        {
            throw new JsonException($"'{name}' is not a valid value for {typeof(TEnum).Name}");
        }

        try
        {
            return SmartEnum<TEnum, TValue>.FromName(name, false);
        }
        catch (Exception ex)
        {
            throw new JsonException($"'{name}' is not a valid value for {typeof(TEnum).Name}", ex);
        }
    }
}