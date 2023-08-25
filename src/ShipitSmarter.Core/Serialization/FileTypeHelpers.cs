namespace ShipitSmarter.Core.Serialization;

/// <summary>
/// Helper to determine what file type, we are dealing with.
/// </summary>
public static class FileTypeHelpers
{
    private static readonly char[] JsonStartChars = new[] { '{', '[' };
    
    /// <summary>
    /// Checks if the text is a json string (eg object or array)
    /// </summary>
    public static bool IsJson(string tIn)
    {
        return JsonStartChars.Contains(tIn.TrimStart().FirstOrDefault());
    }
}