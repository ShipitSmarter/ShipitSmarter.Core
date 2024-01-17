using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using ShipitSmarter.Core.Constants;

namespace ShipitSmarter.Core.AspNet.Filters;

/// <summary>
/// An <see cref="IStartupFilter"/> that logs the <see cref="ILoggableSettings"/> objects to Console.Out on app startup
/// </summary>
/// <code>
/// builder.ConfigureSettings&lt;MySettings&gt;(nameof(MySettings));
/// </code>
public class SettingsLoggerStartupFilter : IStartupFilter
{
    private readonly IEnumerable<ILoggableSettings> _settingsToLog;

    /// <see cref="SettingsLoggerStartupFilter"/>
    public SettingsLoggerStartupFilter(IEnumerable<ILoggableSettings> settingsToLog)
    {
        _settingsToLog = settingsToLog;
    }

    /// <inheritdoc cref="IStartupFilter.Configure"/>
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        foreach (var setting in _settingsToLog)
        {
            var json = JsonSerializer.Serialize((object)setting, JsonSerializationConstants.Options); // cast to Object otherwise serialize returns nothing
            Console.WriteLine($"Setting {setting.GetType().Name}: {json}");
        }

        return next;
    }
}