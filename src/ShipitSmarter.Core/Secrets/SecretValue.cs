using System.Text.Json.Serialization;

namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Wrapper class that holds a secret
/// </summary>
/// <typeparam name="T">The Type of the secret value</typeparam>
public class SecretValue<T> : ISecretValue
{
    /// <summary>
    /// Create a secret, optionally set updated to true
    /// </summary>
    public SecretValue(T value, bool isUpdated = false)
    {
        Updated = isUpdated;
        Value = value;
    }

    /// <summary>
    /// The value of the secret
    /// </summary>
    [JsonIgnore]
    public T Value { get; private set; }

    /// <inheritdoc cref="ISecretValue.Updated"/>
    public bool Updated { get; private set; }

    /// <inheritdoc cref="ISecretValue.GetValue"/>
    public object GetValue() => Value ?? throw new NullReferenceException("SecretValue is null");
    
    /// <summary>
    /// Update the secret with a new value
    /// </summary>
    /// <param name="newValue">The new value to set for the secret</param>
    public void Set(T newValue)
    {
        Updated = true;
        Value = newValue;
    }
}