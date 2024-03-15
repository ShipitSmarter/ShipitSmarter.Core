using System.Text.Json.Serialization;

namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Wrapper class that holds an encrypted secret
/// </summary>
public class SecretValue
{
    /// <summary>
    /// Create a secret, optionally set updated to true
    /// </summary>
    public SecretValue(string encryptedData, string keyId, bool isUpdated = false)
    {
        EncryptedData = encryptedData;
        Updated = isUpdated;
        KeyId = keyId;
    }

    /// <summary>
    /// The encrypted data of the secret (as base64 string)
    /// </summary>
    public string EncryptedData { get; private set; }

    /// <summary>
    /// Placeholder that tracks if the value has been updated 
    /// </summary>
    public bool Updated { get; private set; }

    /// <summary>
    /// Id of the key used to encrypt (SSH-RSA public key)
    /// </summary>
    public string KeyId { get; private set; }
}