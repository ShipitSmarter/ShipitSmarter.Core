using System.Text.Json.Serialization;
using Ardalis.SmartEnum;

namespace ShipitSmarter.Core.Enumerations.v1;

/// <summary>
/// Types of FTP connections allowed by FTP Uploader
/// </summary>
[JsonConverter(typeof(SmartEnumNameConverter<CountryCode, string>))]
public sealed class FtpConnectionType : SmartEnum<FtpConnectionType, string>
{
    // NOTE: this enum is a SmartEnum, because conversion from/to yaml of enum values in capitals does not work well if
    // it was an ordinary enum (since we expect camelCase in all Yaml values).
    
    // ReSharper disable InconsistentNaming
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static readonly FtpConnectionType SFTP = new(nameof(SFTP), "SSH File Transfer Protocol");
    public static readonly FtpConnectionType FTPS = new(nameof(FTPS), "Secure File Transfer Protocol");
    // ReSharper enable InconsistentNaming
    public string TwoLetterCode => Name;

    private FtpConnectionType(string name, string value) : base(name, value)
    {
    }
    
    public static implicit operator string(FtpConnectionType ftpConnectionType) => ftpConnectionType.Name;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}