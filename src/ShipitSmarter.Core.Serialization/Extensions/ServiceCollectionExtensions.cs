
using ShipitSmarter.Core.Secrets;
using ShipitSmarter.Core.Serialization.Secrets;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extension methods for the <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers implementation for <see cref="ISecretConfigFileReader"/>
    /// </summary>
    public static IServiceCollection AddSecretConfigFileReader(this IServiceCollection services)
    {
        services.AddScoped<IFileHandling, FileSystemFileHandling>();
        services.AddScoped<ISecretConfigFileReader, SecretConfigFileManager>();
        return services;
    }
}