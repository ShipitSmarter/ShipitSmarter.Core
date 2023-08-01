using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;

namespace ShipitSmarter.Core.Implementations;

#pragma warning disable CS1591
public class Globber : IGlobPattern
{
    public IEnumerable<string> GetAbsoluteFilePathsFromGlobPattern(string absolutePath, params string[] globPatterns)
    {
        var matches = GetPatternMatchingResult(absolutePath, globPatterns);
        return matches.Files.Select(file => Path.Join(absolutePath, file.Path));
    }
    
    public IEnumerable<string> GetRelativeFilePathsFromGlobPattern(string relativePath, string absolutePath, params string[] globPatterns)
    {
        var matches = GetPatternMatchingResult(absolutePath, globPatterns);
        return matches.Files.Select(file => Path.Join(relativePath, file.Path));
    }
    
    private static PatternMatchingResult GetPatternMatchingResult(string absolutePath, params string[] globPatterns)
    {
        var folder = new DirectoryInfo(absolutePath);
        var matcher = new Matcher();
        foreach (var globPattern in globPatterns)
        {
            matcher.AddInclude(globPattern);
        }
        
        var matches = matcher.Execute(new DirectoryInfoWrapper(folder));
        return matches;
    }
}
#pragma warning restore CS1591