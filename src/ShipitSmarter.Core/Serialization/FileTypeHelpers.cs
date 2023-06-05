namespace ShipitSmarter.Core.Serialization;

public static class FileTypeHelpers
{
    private static readonly char[] JsonStartChars = new[] { '{', '[' };
    
    public static bool IsJson(string tIn)
    {
        return JsonStartChars.Contains(tIn.TrimStart().FirstOrDefault());
    }
}