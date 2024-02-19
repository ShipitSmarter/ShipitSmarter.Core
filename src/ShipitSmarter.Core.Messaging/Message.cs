namespace ShipitSmarter.Core.Messaging;

/// <summary>
/// DTO for sending and receiving messages.
/// </summary>
public class Message
{
    /// <summary>
    /// Unique identifier of this message.
    /// </summary>
    public string Id { get; set; } = string.Empty;
    /// <summary>
    /// The subject of the message. Tells the receiver how to handle this message.
    /// </summary>
    public string Subject { get; }
    /// <summary>
    /// An id correlating this message to a process.
    /// </summary>
    public Guid CorrelationId { get; set; }
    /// <summary>
    /// Extra attributes for this message.
    /// </summary>
    public Dictionary<string, string> Attributes { get; } = [];
    /// <summary>
    /// The serialized message data.
    /// </summary>
    public byte[] Data { get; }

    public Message(string subject, byte[] data)
    {
        Subject = subject;
        Data = data;
    }
}
