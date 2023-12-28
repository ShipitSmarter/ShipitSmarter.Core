using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShipitSmarter.Core.Documentation;

/// <summary>
/// Filter to add to model.Required all properties where Nullable is false.
/// <see href="https://stackoverflow.com/questions/46576234/swashbuckle-make-non-nullable-properties-required"/>
///
/// <code>
/// services.AddSwaggerGen(c =>
/// {
///     c.SchemaFilter&lt;RequireNonNullablePropertiesSchemaFilter&gt;();
///     c.SupportNonNullableReferenceTypes(); // Sets Nullable flags appropriately. 
/// }
/// </code>
/// </summary>
public class RequireNonNullablePropertiesSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Add to model.Required all properties where Nullable is false.
    /// </summary>
    public void Apply(OpenApiSchema model, SchemaFilterContext context)
    {
        var additionalRequiredProps = model.Properties
            .Where(x => !x.Value.Nullable && !model.Required.Contains(x.Key))
            .Select(x => x.Key);
        foreach (var propKey in additionalRequiredProps)
        {
            model.Required.Add(propKey);
        }
    }
}