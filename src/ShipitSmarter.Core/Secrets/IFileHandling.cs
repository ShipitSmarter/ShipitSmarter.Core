namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Provides methods to read, write and check if a file exists.
/// </summary>
public interface IFileHandling
{
    /// <summary>
    /// Determines whether the specified file exists.
    /// </summary>
    /// <param name="path">The file to check.</param>
    /// <returns>True if the file exists, otherwise false</returns>
    bool Exists(string path);
    
    /// <summary>
    /// Opens a text file, reads all the text in the file into a string, and then closes the file.
    /// </summary>
    /// <param name="path">The file to open for reading.</param>
    /// <returns>A string containing all the text in the file.</returns>
    string ReadAllText(string path);
    
    /// <summary>
    /// Creates a new file, write the contents to the file, and then closes the file. If the target file already exists, it is truncated and overwritten.
    /// </summary>
    /// <param name="path">The file to write to.</param>
    /// <param name="contents">The string to write to the file.</param>
    void WriteAllText(string path, string contents);
}