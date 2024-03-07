namespace ShipitSmarter.Core.Secrets;

/// <summary>
/// Interface that helps with secrets
/// </summary>
public interface ISecretValue
{
    /// <summary>
    /// Placeholder that tracks if the value has been updated 
    /// </summary>
    bool Updated { get; }
    
    /// <summary>
    /// Retrieves the value of the secret
    /// </summary>
    object GetValue();
}