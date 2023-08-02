using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ShipitSmarter.Core;
using ShipitSmarter.Core.Filters;
using ShipitSmarter.Core.Implementations;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configure TSettings from configuration
/// </summary>
/// <code>
/// // in the Program.cs
/// builder.Services.ConfigureSettings&lt;MySettings&gt;(builder.Configuration, nameof(MySettings)); 
/// </code>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configure TSettings from configuration
    /// You can now inject the "raw" settings object into your handlers, without taking a dependency on the Microsoft.Extensions.Options package.
    /// I find this preferable as the IOptions&lt;TSettings&gt; interface is largely just noise in this case.
    /// </summary>
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

    /// <summary>
    /// Add an <see cref="IStartupFilter"/> to the application that logs all registered <see cref="ILoggableSettings"/> objects
    /// </summary>
    public static IServiceCollection AddSettingsLogging(this IServiceCollection services)
    {
        return services.AddTransient<IStartupFilter, SettingsLoggerStartupFilter>();
    }
}