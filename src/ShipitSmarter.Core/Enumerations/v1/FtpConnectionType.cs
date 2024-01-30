namespace ShipitSmarter.Core.Enumerations.v1;

/// <summary>
/// Types of FTP connections allowed by FTP Uploader
/// </summary>
public enum FtpConnectionType
{
    // ReSharper disable InconsistentNaming
    
    /// <summary>
    /// SSH File Transfer Protocol
    /// </summary>
    SFTP,
    
    /// <summary>
    /// Secure File Transfer Protocol
    /// </summary>
    FTPS
    
    // ReSharper enable InconsistentNaming
}