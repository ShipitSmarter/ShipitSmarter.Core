namespace ShipitSmarter.Core.Messaging;

/// <typeparam name="TMessage">Type of the message data</typeparam>
public interface IMessageContract<TMessage>
    where TMessage : IMessageContract<TMessage>
{
    /// <summary>
    /// The subject applied to messages for this contract.
    /// </summary>
    static abstract string Subject { get; }

    /// <summary>
    /// Deserializes the received message to <typeparamref name="TMessage"/>.
    /// </summary>
    /// <param name="message">The received message.</param>
    /// <returns>The message data as <typeparamref name="TMessage"/>.</returns>
    static abstract TMessage Deserialize(Message message);
    /// <summary>
    /// Serializes the data and creates a <see cref="Message"/> to send.
    /// </summary>
    /// <param name="data">The data that will be serialized.</param>
    /// <returns>A <see cref="Message"/>.</returns>
    Message Serialize();
}
