
// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.Configuration;

/// <summary>
/// Set of extensions for Configuration Manager
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    /// Get environment variable and throw exception if empty
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="key">Environment variable</param>
    /// <typeparam name="T">Type of key expected</typeparam>
    /// <returns>Type of T</returns>
    /// <exception cref="ApplicationException">Key not defined</exception>
    public static T GetValueOrThrow<T>(this IConfiguration configuration, string key)
    {
        return configuration.GetValue<T>(key) ??
               throw new ApplicationException($"'{key}' not defined in environment variables");
    }
}