using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ShipitSmarter.Core.AspNet.Documentation;


/// <summary>
/// Helper class to standardize SwaggerDoc generation
/// </summary>
public static class SwaggerDocHelper
{

    /// <summary>
    /// Adds the Viya logo in redoc.
    /// </summary>
    public static void AddViyaLogo(this Dictionary<string, IOpenApiExtension> extensions)
    {
        // https://github.com/Redocly/redoc/blob/main/docs/redoc-vendor-extensions.md#logo-object
        extensions.Add("x-logo", new OpenApiObject
        {
            { "url", new OpenApiString("https://viya.me/images/viya-logo.png") },
            { "altText", new OpenApiString("Viya logo") },
        });
    }

    /// <summary>
    /// Add PAT header security configuration for <see cref="SwaggerGenOptions"/> using AddSecurityDefinition and AddSecurityRequirement
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

    /// <summary>
    /// Add production server for specific API
    /// </summary>
    /// <param name="options"></param>
    /// <param name="serviceSlug">The slug of the service, for example 'ftp-uploader'</param>
    public static void AddProductionServer(this SwaggerGenOptions options, string serviceSlug)
    {
        options.AddServer(new OpenApiServer
        {
            Description = "The production API server",
            Url = "https://{customername}.viya.me/api/" + serviceSlug,
            Variables = new Dictionary<string, OpenApiServerVariable>
            {
                { "customername", new OpenApiServerVariable
                    {
                        Default = "demo",
                        Description = "this value is assigned by the service provider, in this example `viya.me`"
                    }
                }
            }
        });
    }
}