using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using ShipitSmarter.Core.Constants;

namespace ShipitSmarter.Core.Filters;

/// <summary>
/// An <see cref="IStartupFilter"/> that logs the <see cref="ILoggableSettings"/> objects to Console.Out on app startup
/// </summary>
/// <example><code>
/// builder.ConfigureSettings<MySettings>(nameof(MySettings));
/// </code></example>
public class SettingsLoggerStartupFilter : IStartupFilter
{
    private readonly IEnumerable<ILoggableSettings> _settingsToLog;

    public SettingsLoggerStartupFilter(IEnumerable<ILoggableSettings> settingsToLog)
    {
        _settingsToLog = settingsToLog;
    }

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