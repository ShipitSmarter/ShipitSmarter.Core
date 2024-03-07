namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Helper to write and read configuration objects that contain secrets to file system
/// </summary>
public interface ISecretConfigFileReaderAndWriter : ISecretConfigFileReader
{
    /// <summary>
    /// Write a configuration object to disk
    /// </summary>
    /// <param name="obj">The configuration object to serialize to disk</param>
    /// <param name="filepath">The filepath to read (uses filename and file extension to determine; files to read and serialize method to use)</param>
    /// <typeparam name="T">The type of configuration object</typeparam>
    public void WriteToDisk<T>(T obj, string filepath);
    
    /// <summary>
    /// Write a configuration object to disk, but only write the secrets if they are updated!
    /// </summary>
    /// <inheritdoc cref="WriteToDisk{T}"/>
    public void WriteToDiskSecretsOnlyWhenUpdated<T>(T obj, string filepath);
}