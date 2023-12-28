using System.Reflection;
using Ardalis.SmartEnum;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShipitSmarter.Core.Documentation;

/// <summary>
/// Apply special swagger doc treatment for SmartEnum types
/// </summary>
public class SmartEnumDocumentFilter : IDocumentFilter
{
    private readonly List<Assembly> _assembliesToScan;

    /// <inheritdoc cref="SmartEnumDocumentFilter"/>
    public SmartEnumDocumentFilter(List<Assembly> assembliesToScan)
    {
        _assembliesToScan = assembliesToScan;
    }

    /// <summary>
    /// List all SmartEnum type options in the swagger doc
    /// </summary>
    /// <param name="swaggerDoc"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        var smartEnumTypes = _assembliesToScan
            .SelectMany(a => a.GetTypes())
            .Where(t => IsTypeDerivedFromGenericType(t, typeof(SmartEnum<,>)));

        foreach (var smartEnumType in smartEnumTypes)
        {
            var schema = GetSchemaForType(smartEnumType, context);
            if (schema == null)
            {
                // The smart enum is not mentioned in the Swagger definition
                continue;
            }
            
            schema.Required = null;
            schema.Properties = null;
            schema.AdditionalProperties = null;

            var enumValues = smartEnumType
                .GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                .Select(x => x.Name);

            var openApiValues = new OpenApiArray();
            openApiValues.AddRange(enumValues.Select(x => new OpenApiString(x)));
            
            schema.Type = "string";
            schema.Enum = openApiValues;
        }
    }
    
    private static OpenApiSchema? GetSchemaForType(Type? type, DocumentFilterContext context)
    {
        // Returns the schema for the type if the schema key is either identical to the type name or ends with $".{type.Name}"
        if (type == null)
        {
            return null;
        }
        
        var candidates = context.SchemaRepository.Schemas
            .Where(x => x.Key == type.Name || x.Key.EndsWith($".{type.Name}"))
            .ToList();

        return candidates.Count switch
        {
            0 => null,
            1 => context.SchemaRepository.Schemas[candidates[0].Key],
            _ => throw new InvalidOperationException($"Multiple schemas found for type {type.Name}"),
        };
    }

    private static bool IsTypeDerivedFromGenericType(Type? typeToCheck, Type genericType)
    {
        if (typeToCheck == typeof(object))
        {
            return false;
        }

        if (typeToCheck == null)
        {
            return false;
        }

        if (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition() == genericType)
        {
            return true;
        }

        return IsTypeDerivedFromGenericType(typeToCheck.BaseType, genericType);
    }
}