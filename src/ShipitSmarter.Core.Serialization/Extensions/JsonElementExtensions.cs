using System.Text.Json;

// ReSharper disable once CheckNamespace
namespace ShipitSmarter.Core.Serialization;


/// <summary>
/// Extension methods for <see cref="JsonElement"/>
/// </summary>
public static class JsonElementExtensions
{
    /// <summary>
    /// System.Text.Json does not support deserializing to a dynamic object, 
    /// the best we can get is a JsonElement.
    ///
    /// This method recursively navigates through the JsonElement and converts it to a dynamic object
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public static object? ConvertToObject(this JsonElement node)
    {
        if (node.ValueKind == JsonValueKind.Array)
            return node.EnumerateArray().Select(ConvertToObject).ToList();
        if (node.ValueKind == JsonValueKind.Object)
            return node.EnumerateObject().ToDictionary(n => n.Name, n => ConvertToObject(n.Value));
        return node.ValueKind switch
        {
            JsonValueKind.String => node.GetString(),
            JsonValueKind.Number => node.GetDecimal(),
            JsonValueKind.True => true,
            JsonValueKind.False => false,
            JsonValueKind.Null => null,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}