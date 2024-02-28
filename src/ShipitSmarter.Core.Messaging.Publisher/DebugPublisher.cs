using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ShipitSmarter.Core.Messaging.Publisher;

/// <summary>
/// <see cref="IPublisher"/> implementation when running in debug where there is no Google PubSub topic available
/// </summary>
public class DebugPublisher : IPublisher
{
    private readonly ILogger<DebugPublisher> _logger;

    public DebugPublisher(ILogger<DebugPublisher> logger)
    {
        _logger = logger;
    }

    public Task Publish<TMessage>(TMessage message) where TMessage : IMessageContract<TMessage>
    {
        _logger.LogInformation($"Mimic publishing message {{message}}", JsonSerializer.Serialize(message));
        return Task.CompletedTask;
    }
}