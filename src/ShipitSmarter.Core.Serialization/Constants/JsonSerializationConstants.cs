using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using ShipitSmarter.Core.Secrets;

namespace ShipitSmarter.Core.Serialization.Constants;

/// <summary>
/// Default for JsonSerializerOptions
/// </summary>
public class JsonSerializationConstants
{
    /// <see cref="JsonSerializationConstants"/>
    public static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web)
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        Converters = { new JsonStringEnumConverter() },
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { IgnoreSecrets }
        }
    };
    
    private static void IgnoreSecrets(JsonTypeInfo typeInfo)
    {
        foreach (var propInfo in typeInfo.Properties)
        {
            if (typeof(ISecretValue).IsAssignableFrom(propInfo.PropertyType))
            {
                // Disable both serialization and deserialization 
                // by unsetting getter and setter delegates
                propInfo.Get = null;
                propInfo.Set = null;
            }
        }
    }
}