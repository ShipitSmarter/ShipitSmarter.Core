using Google.Cloud.PubSub.V1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ShipitSmarter.Core.Messaging.Subscriber;

public class GoogleSubscriberClient : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly ILogger<GoogleSubscriberClient> _logger;

    private readonly SubscriberClient _subscriber;

    public GoogleSubscriberClient(
        SubscriberClient subscriber,
        IServiceProvider services,
        ILogger<GoogleSubscriberClient> logger
    )
    {
        _subscriber = subscriber;
        _services = services;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"{nameof(GoogleSubscriberClient)} Hosted Service running.");

        await _subscriber.StartAsync(async (msg, token) => {
            _logger.LogInformation("Handling message {messageId}", msg.MessageId);

            try {
                using var scope = _services.CreateScope();
                var handler = scope.ServiceProvider.GetRequiredService<IMessageHandler>();
                var message = Map(msg);

                using (_logger.BeginScope(new List<KeyValuePair<string, object>>{
                    new("correlationId", message.CorrelationId),
                }))
                {
                    await handler.Handle(message);

                    _logger.LogInformation("Succesfully handled message {messageId}", msg.MessageId);
                    return SubscriberClient.Reply.Ack;
                }
            }
            catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        });
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"{nameof(GoogleSubscriberClient)} Hosted Service is stopping.");

        await _subscriber.StopAsync(stoppingToken);

        await base.StopAsync(stoppingToken);
    }

    private Message Map(PubsubMessage message) {
        if (!message.Attributes.TryGetValue("subject", out var subject)) {
            throw new MessageException("No subject attribute found");
        }

        if (!message.Attributes.TryGetValue("correlation-id", out var correlationIdAttr)) {
            _logger.LogDebug("No correlation-id attribute on message {messageId}", message.MessageId);
        }

        Guid correlationId = Guid.NewGuid();
        if (correlationIdAttr != null && !Guid.TryParse(correlationIdAttr, out correlationId)) {
            _logger.LogWarning("Cannot parse correlation-id attribute '{correlationId}' on message {messageId}", correlationIdAttr, message.MessageId);
            correlationId = Guid.NewGuid();
        }

        var data = message.Data.ToByteArray();
        var msg = new Message(subject, data) {
            Id = message.MessageId,
            CorrelationId = correlationId,
        };

        var skipAttributes = new [] { "subject", "correlation-id" };
        foreach (var (key, value) in message.Attributes)
            if (!skipAttributes.Contains(key))
                msg.Attributes.Add(key, value);

        return msg;
    }
}
