using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ShipitSmarter.Core;
using ShipitSmarter.Core.Secrets;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for the <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configure TSettings from configuration
    /// You can now inject the "raw" settings object into your handlers, without taking a dependency on the Microsoft.Extensions.Options package.
    /// I find this preferable as the IOptions&lt;TSettings&gt; interface is largely just noise in this case.
    /// </summary>
    /// <example>services.ConfigureSettings&lt;MySettings&gt;(builder.Configuration, nameof(MySettings));</example>
    public static IServiceCollection ConfigureSettings<TSettings>(this IServiceCollection services, IConfiguration configuration,
        string configurationSectionKey) where TSettings : class, new()
    {
        var settings = configuration.GetSection(configurationSectionKey);
        services.Configure<TSettings>(settings);
        services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<TSettings>>().Value);
        if (typeof(TSettings).GetInterfaces().Contains(typeof(ILoggableSettings)))
        {
            services.AddSingleton<ILoggableSettings>(resolver => (ILoggableSettings)resolver.GetRequiredService<IOptions<TSettings>>().Value);
        }
        return services;
    }
}