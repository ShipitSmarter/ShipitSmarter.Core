using System.ComponentModel.DataAnnotations;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// Ftp Server host name and port number
/// </summary>
[Serializable]
public class FtpServerHost
{
    /// <summary>
    /// Host name
    /// </summary>
    [Required]
    public string HostName { get; set; } = null!;

    /// <summary>
    /// Port number
    /// </summary>
    [Required]
    public int PortNumber { get; set; } = int.MinValue;
}