using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShipitSmarter.Core.AspNet.Documentation;


/// <summary>
/// Helper class to standardize SwaggerDoc generation
/// </summary>
public static class SwaggerDocHelper
{

    /// <summary>
    /// Add this to <see cref="OpenApiInfo.Extensions"/> to display to Viya logo in redoc.
    /// </summary>
    public static KeyValuePair<string, OpenApiObject> ViyaLogo =
        // https://github.com/Redocly/redoc/blob/main/docs/redoc-vendor-extensions.md#logo-object
        new("x-logo", new OpenApiObject
        {
            { "url", new OpenApiString("https://viya.me/images/viya-logo.png") },
            { "altText", new OpenApiString("Viya logo") },
        });

    /// <summary>
    /// Add PAT header configuration for <see cref="SwaggerGenOptions"/> using AddSecurityDefinition and AddSecurityRequirement
    /// </summary>
    public static void AddPatSecurityConfiguration(this SwaggerGenOptions options)
    {
        options.AddSecurityDefinition("pat", new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.ApiKey,
            In = ParameterLocation.Header,
            Name = "x-api-pat"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "pat" },
                },
                new List<string>()
            }
        });
    }
}