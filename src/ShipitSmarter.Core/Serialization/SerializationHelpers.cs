using System.Text.Json;
using Json.Schema;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ShipitSmarter.Core.Serialization;

/// <summary>
/// Helper to for serialization
/// </summary>
public static class SerializationHelpers
{
    /// <summary>
    /// Convert schemeContent text into a <see cref="JsonSchema"/>
    /// </summary>
    public static JsonSchema DeserializeJsonSchema(string schemaContent)
    {
        var schemaStringJson = FileTypeHelpers.IsJson(schemaContent)
            ? schemaContent
            : ConvertYamlToJson(schemaContent); 
        // Have to convert JsonSchema in Yaml format to Json first before validating against JsonDocument
        // from https://stackoverflow.com/a/72417980/1716283
        var jsonSchema = JsonSchema.FromText(schemaStringJson);
        return jsonSchema;
    }
    
    
    /// <summary>
    /// Converts yaml to json
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    public static string ConvertYamlToJson(string yaml) 
    {
        object DeserializeYaml() =>
            new DeserializerBuilder()
                .IgnoreUnmatchedProperties()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .WithTypeConverter(new ObjectYamlTypeConverter())
                .Build()
                .Deserialize(new StringReader(yaml))
            ?? throw new InvalidOperationException("Cannot deserialize yaml string:" + Environment.NewLine + yaml);

        var yamlObject = DeserializeYaml();
        
        var json = JsonSerializer.Serialize(yamlObject);
   
        return json;
    }
}