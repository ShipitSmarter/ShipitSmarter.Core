using System.ComponentModel.DataAnnotations;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Document
/// </summary>
[Serializable]
public abstract class Document(string fileExtension, string fileName, string fileContent)
{
    /// <summary>
    /// The extension of the file, e.g. "pdf"
    /// </summary>
    /// <example>"pdf"</example>
    [Required(AllowEmptyStrings = false)]
    public string FileExtension { get; set; } = fileExtension;

    /// <summary>
    /// The name of the file, e.g. "my-file.pdf"
    /// </summary>
    /// <example>"my-file.pdf"</example>
    [Required(AllowEmptyStrings = false)]
    public string FileName { get; set; } = fileName;

    /// <summary>
    /// The byte content of the file encoded in base64
    /// </summary>
    [Required(AllowEmptyStrings = false)]
    public string FileContent { get; set; } = fileContent;
}
