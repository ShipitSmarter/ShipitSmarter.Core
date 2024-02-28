namespace ShipitSmarter.Core;

/// <summary>
/// Helper to watch for directory/file changes and notify.
/// </summary>
public interface IDirectoryWatcher
{
    /// <summary>
    /// Start watching the directory for changes
    /// </summary>
    /// <param name="path">The path to watch</param>
    /// <param name="filter">Filter string, *.* watches all files</param>
    /// <param name="onchangeDetected">The callback action to execute when a change is detected</param>
    void Start(string path, string filter, Action onchangeDetected);

    /// <summary>
    /// Stop watching
    /// </summary>
    void Stop();
}