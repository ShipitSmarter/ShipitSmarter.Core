using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShipitSmarter.Core.AspNet.Documentation;


/// <summary>
/// Swagger filter to add a clarification to DateTime schema to indicate that it is not allowed to specify a time zone
/// </summary>
public class LocalDateTimeSchemaFilter : ISchemaFilter
{
    /// <summary>
    /// Adds a clarification to DateTime schema to indicate that it is not allowed to specify a time zone
    /// </summary>
    /// <param name="schema"></param>
    /// <param name="context"></param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type != typeof(DateTime) && context.Type != typeof(DateTime?))
        {
            return;
        }

        schema.Description += ". NOTE: Time zone specification is not allowed";
    }
}