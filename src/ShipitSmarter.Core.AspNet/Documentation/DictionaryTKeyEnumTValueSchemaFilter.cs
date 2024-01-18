using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShipitSmarter.Core.AspNet.Documentation;

/// <summary>
/// Updates the API documentation for any Dictionary&lt;Enum, TValue&gt; fields to show the enum values as possible keys
/// Adds 3 example keys to the schema instead of using the `AdditionalProperties` schema function
/// 
/// When OpenApi 3.1 is included in swashbuckle, this can be replaced with the `PatternProperties` schema function
/// https://stackoverflow.com/questions/46552863/how-to-write-openapi-3-swagger-specification-for-property-name-in-map-object/46553255#46553255
/// Here is the current roadmap for Microsoft OpenAi integration: https://github.com/microsoft/OpenAPI.NET/issues/795
/// </summary>
public class DictionaryTKeyEnumTValueSchemaFilter : ISchemaFilter
{
    /// <inheritdoc cref="ISchemaFilter.Apply"/>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // Only run for fields that are a Dictionary<Enum, TValue>
        if (!context.Type.IsGenericType || !context.Type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>)))
        {
            return;
        }

        var keyType = context.Type.GetGenericArguments()[0];
        var valueType = context.Type.GetGenericArguments()[1];

        if (!keyType.IsEnum)
        {
            return;
        }

        schema.Type = "object";
        schema.AdditionalPropertiesAllowed = false;
        
        var enumNames = keyType.GetEnumNames();
        var valuesStr = string.Join(", ", enumNames.Select(e => $"`{e}`"));
        schema.Description += $". Valid property name values are: {valuesStr}";
        
        // schema.Enum = enumNames.Select(e => new OpenApiString(e)).Cast<IOpenApiAny>().ToList();
        schema.Properties = enumNames.Take(enumNames.Length >= 3 ? 3 : enumNames.Length).ToDictionary(name => name,
            name => context.SchemaGenerator.GenerateSchema(valueType,
                context.SchemaRepository));
    }
}