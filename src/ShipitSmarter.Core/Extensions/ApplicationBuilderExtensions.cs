using System.Globalization;
using Microsoft.AspNetCore.Localization;

// ReSharper disable once CheckNamespace
namespace Microsoft.AspNetCore.Builder;

/// <summary>
/// Extensions for <see cref="IApplicationBuilder"/>
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    /// Configure the <see cref="IApplicationBuilder"/> to use <see cref="CultureInfo.InvariantCulture"/> for Request Localization
    /// </summary>
    public static IApplicationBuilder UseInvariantCulture(this IApplicationBuilder app)
    {
        var supportedCultures = new[] { CultureInfo.InvariantCulture };
        app.UseRequestLocalization(new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture(supportedCultures[0]),
            // Formatting numbers, dates, etc.
            SupportedCultures = supportedCultures,
            // UI strings that we have localized.
            SupportedUICultures = supportedCultures
        });
        return app;
    }
}