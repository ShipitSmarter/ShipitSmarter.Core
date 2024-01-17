using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using ShipitSmarter.Core.AspNet.Implementations;

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

    /// <summary>
    /// Configure the <see cref="IApplicationBuilder"/> to use Exception Handler that always returns a <see cref="ProblemDetails"/>
    /// </summary>
    /// <param name="app"></param>
    /// <param name="wrapper"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseProblemDetailsForExceptions(this IApplicationBuilder app,
        ProblemDetailsWrapper? wrapper = null)
    {
        app.UseExceptionHandler(new ExceptionHandlerOptions
        {
            AllowStatusCode404Response = true,
            ExceptionHandler = context => CoreExceptionHandler.Handle(context, wrapper ?? new ProblemDetailsWrapper())
        });
        return app;
    }
}