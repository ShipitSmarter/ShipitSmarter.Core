namespace ShipitSmarter.Core.Exceptions;

/// <summary>
/// Detailed definition of an error included in an ErrorResponse
/// </summary>
[Serializable]
public class Error
{
    /// <summary>
    /// Unique Error code for this type of error, can be carrier assigned or if carrier did not assign: integration assigned
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Human readable message for that code which can include transactional information, or carrier specific response
    /// </summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Additional information to clarify the message to the user. Optional
    /// </summary>
    public string? Explanation { get; set; }
}