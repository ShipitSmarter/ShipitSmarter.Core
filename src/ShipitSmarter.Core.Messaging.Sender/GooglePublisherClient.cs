using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Microsoft.Extensions.Logging;

namespace ShipitSmarter.Core.Messaging.Sender;

public class GooglePublisherClient : ISender
{
    private readonly PublisherClient _publisher;
    private readonly ICorrelator _correlator;
    private readonly ILogger<GooglePublisherClient> _logger;

    public GooglePublisherClient(
        PublisherClient publisher,
        ICorrelator correlator,
        ILogger<GooglePublisherClient> logger
    )
    {
        _publisher = publisher;
        _correlator = correlator;
        _logger = logger;
    }

    public async Task Send<TMessage>(TMessage message)
        where TMessage : IMessageContract<TMessage>
    {
        var serializedMessage = message.Serialize();
        serializedMessage.CorrelationId = _correlator.CurrentCorrelationId;

        _logger.LogInformation("Sending message {@message} to topic {@topic}", serializedMessage, _publisher.TopicName);
        var messageId = await _publisher.PublishAsync(Map(serializedMessage));
        _logger.LogInformation("Message sent with id {messageId}", messageId);
    }

    private static PubsubMessage Map(Message msg) {
        var result = new PubsubMessage() {
            Data = ByteString.CopyFrom(msg.Data),
        };

        result.Attributes.Add("subject", msg.Subject);
        result.Attributes.Add("correlation-id", msg.CorrelationId.ToString());

        foreach (var (key, value) in msg.Attributes)
            result.Attributes.Add(key, value);

        return result;
    }
}
