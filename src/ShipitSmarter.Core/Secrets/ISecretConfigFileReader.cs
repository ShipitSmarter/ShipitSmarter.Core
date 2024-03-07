namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Helper to read configuration objects that contain secrets from file system
/// </summary>
public interface ISecretConfigFileReader
{
    /// <summary>
    /// Read a configuration object from disk
    /// </summary>
    /// <param name="filepath">The filepath to read (uses filename and file extension to determine; files to read and serialize method to use)</param>
    /// <typeparam name="T">The type of configuration object you want to serialize to</typeparam>
    /// <returns>The configuration object</returns>
    public T ReadFromDisk<T>(string filepath);
}