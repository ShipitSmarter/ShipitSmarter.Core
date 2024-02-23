// ReSharper disable once CheckNamespace
namespace System.Runtime;

/// <summary>
/// Extensions for <see cref="String"/>
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Try converting the <see cref="String"/> to a <see cref="Guid"/>
    /// </summary>
    /// <param name="input">The text to be converted</param>
    /// <returns>A guid when success, otherwise null</returns>
    public static Guid? ToGuid(this string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }
        
        if (Guid.TryParse(input, out var tmpId))
        {
            return tmpId;
        }

        return null;
    }
}