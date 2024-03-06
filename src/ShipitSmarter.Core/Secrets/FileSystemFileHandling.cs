namespace ShipitSmarter.Core.Secrets;

/// <inheritdoc />
public class FileSystemFileHandling : IFileHandling
{
    /// <inheritdoc />
    public bool Exists(string path) => File.Exists(path);

    /// <inheritdoc />
    public string ReadAllText(string path) => File.ReadAllText(path);

    /// <inheritdoc />
    public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
}