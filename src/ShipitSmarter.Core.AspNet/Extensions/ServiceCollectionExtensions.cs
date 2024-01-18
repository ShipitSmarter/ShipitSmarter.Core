using Microsoft.AspNetCore.Hosting;
using ShipitSmarter.Core;
using ShipitSmarter.Core.AspNet.Filters;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Configure TSettings from configuration
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add an <see cref="IStartupFilter"/> to the application that logs all registered <see cref="ILoggableSettings"/> objects
    /// </summary>
    public static IServiceCollection AddSettingsLogging(this IServiceCollection services)
    {
        return services.AddTransient<IStartupFilter, SettingsLoggerStartupFilter>();
    }
}