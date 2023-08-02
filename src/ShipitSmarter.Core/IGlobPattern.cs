namespace ShipitSmarter.Core;

/// <summary>
/// Find files based on glob patterns
/// </summary>
public interface IGlobPattern
{
    /// <summary>
    /// Find files based on glob pattern.
    /// </summary>
    /// <param name="absolutePath"></param>
    /// <param name="globPatterns"></param>
    /// <returns>List of found file paths (absolute)</returns>
    IEnumerable<string> GetAbsoluteFilePathsFromGlobPattern(string absolutePath, params string[] globPatterns);
    
    /// <summary>
    /// Find files based on glob pattern.
    /// </summary>
    /// <param name="relativePath"></param>
    /// <param name="absolutePath"></param>
    /// <param name="globPatterns"></param>
    /// <returns>List of found file paths (relative)</returns>
    IEnumerable<string> GetRelativeFilePathsFromGlobPattern(string relativePath, string absolutePath, params string[] globPatterns);
}