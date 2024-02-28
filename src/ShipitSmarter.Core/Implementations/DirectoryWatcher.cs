using Microsoft.Extensions.Logging;
using Timer = System.Timers.Timer;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ShipitSmarter.Core.Implementations;

public class DirectoryWatcher : IDirectoryWatcher
{
    private readonly ILogger<DirectoryWatcher> _logger;
    private Timer? _debounceTimer = null;
    private FileSystemWatcher? _watcher = null;

    public DirectoryWatcher(ILogger<DirectoryWatcher> logger)
    {
        _logger = logger;
    }

    public void Start(string path, string filter, Action onchangeDetected)
    {
        if (_watcher != null)
        {
            throw new ApplicationException("Cannot start watcher twice");
        }
        
        _debounceTimer = new Timer();
        _debounceTimer.Interval = 200;
        _debounceTimer.AutoReset = false; // Elapsed is triggered only once!
        _debounceTimer.Elapsed += (sender, args) => onchangeDetected();

        _watcher = new FileSystemWatcher(path);
        _watcher.NotifyFilter = NotifyFilters.CreationTime
                                | NotifyFilters.DirectoryName
                                | NotifyFilters.FileName
                                | NotifyFilters.LastWrite
                                | NotifyFilters.Size;
        
        _watcher.Changed += WatcherOnChanged;
        _watcher.Created += WatcherOnCreated;
        _watcher.Deleted += WatcherOnDeleted;
        _watcher.Renamed += WatcherOnRenamed;
        _watcher.Error += WatcherOnError;
        
        _watcher.Filter = filter;
        _watcher.IncludeSubdirectories = true;
        _watcher.EnableRaisingEvents = true;
    }
    
    public void Stop()
    {
        _watcher?.Dispose();
        _debounceTimer?.Dispose();
    }
    
    private void ResetTimer()
    {
        _debounceTimer?.Stop();
        _debounceTimer?.Start();
    }
    
    private void WatcherOnError(object sender, ErrorEventArgs e)
    {
        
        _logger.LogError(e.GetException(), $"An error occured with the FileSystemWatcher (watching: {_watcher?.Path})");
        _debounceTimer?.Stop();
    }
    
    private void WatcherOnRenamed(object sender, RenamedEventArgs e)
    {
        _logger.LogDebug($"WatcherOnRenamed: {e.OldFullPath} to {e.FullPath} -> {e.ChangeType}");
        ResetTimer();
    }

    private void WatcherOnDeleted(object sender, FileSystemEventArgs e)
    {
        _logger.LogDebug($"WatcherOnDeleted: {e.FullPath} -> {e.ChangeType}");
        ResetTimer();
    }

    private void WatcherOnCreated(object sender, FileSystemEventArgs e)
    {
        _logger.LogDebug($"WatcherOnCreated: {e.FullPath} -> {e.ChangeType}");
        ResetTimer();
    }

    private void WatcherOnChanged(object sender, FileSystemEventArgs e)
    {
        _logger.LogDebug($"WatcherOnChanged: {e.FullPath} -> {e.ChangeType}");
        ResetTimer();
    }
}