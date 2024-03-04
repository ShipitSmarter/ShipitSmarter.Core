namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Exception related to reading/writing secrets.
/// </summary>
public class SecretException : Exception
{
    /// <inheritdoc />
    public SecretException(string message): base(message)
    {
    }
}