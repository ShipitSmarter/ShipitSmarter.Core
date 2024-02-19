using System.Text.Json;

namespace ShipitSmarter.Core.Messaging;

/// <summary>
/// Implementation of <see cref="IMessageContract{TMessage}"/> that serializes the data as UTF-8 encoded JSON.
/// </summary>
/// <typeparam name="TMessage">Type of the message data</typeparam>
public class JsonMessageContract<TMessage> : IMessageContract<TMessage>
    where TMessage : JsonMessageContract<TMessage>
{
    public string Subject => typeof(TMessage).FullName!;

    public static TMessage Deserialize(Message message)
    {
        return JsonSerializer.Deserialize<TMessage>(message.Data)
            ?? throw new MessageException($"{nameof(Message.Data)} cannot be null");
    }

    public Message Serialize()
    {
        var json = JsonSerializer.SerializeToUtf8Bytes((TMessage)this);
        var msg = new Message(Subject, json);

        msg.Attributes.Add("Content-Type", "application/json");

        return msg;
    }
}
