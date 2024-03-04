namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Wrapper class that holds a secret
/// </summary>
/// <param name="value">The secret value</param>
/// <typeparam name="T">The Type of the secret value</typeparam>
public class SecretValue<T>(T value) : ISecretValue
{
    /// <inheritdoc cref="ISecretValue.Updated"/>
    public bool Updated { get; private set; } = false;
    
    /// <inheritdoc cref="ISecretValue.GetValue"/>
    public object GetValue() => value ?? throw new NullReferenceException("SecretValue is null");
    
    /// <summary>
    /// Update the secret with a new value
    /// </summary>
    /// <param name="newValue">The new value to set for the secret</param>
    public void Set(T newValue)
    {
        Updated = true;
        value = newValue;
    }
}