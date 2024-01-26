using ShipitSmarter.Core.DataAnnotations;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Document
/// </summary>
[Serializable]
public class Document()
{
    /// <summary>
    /// The extension of the file, e.g. "pdf"
    /// </summary>
    /// <example>"pdf"</example>
    [RequiredNotDefault]
    public string FileExtension { get; set; } = Defaults.String;

    /// <summary>
    /// The name of the file, e.g. "my-file.pdf"
    /// </summary>
    /// <example>"my-file.pdf"</example>
    [RequiredNotDefault]
    public string FileName { get; set; } = Defaults.String;

    /// <summary>
    /// The byte content of the file encoded in base64
    /// </summary>
    [RequiredNotDefault]
    public string FileContent { get; set; } = Defaults.String;
}
