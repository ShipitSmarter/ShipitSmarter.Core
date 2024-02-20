using FluentAssertions;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace ShipitSmarter.Core.Messaging.Receiver.Tests;

public class GoogleSubscriberClientTests
{
    [Fact]
    public async Task ExecuteAsync_MapsToHandlerCorrectly()
    {
        // Arrange
        Func<PubsubMessage,CancellationToken,Task<SubscriberClient.Reply>> handler = null!;
        Message message = null!;

        var subscriberMock = new Mock<SubscriberClient>();
        subscriberMock
            .Setup(m => m.StartAsync(It.IsAny<Func<PubsubMessage,CancellationToken,Task<SubscriberClient.Reply>>>()))
            .Callback<Func<PubsubMessage,CancellationToken,Task<SubscriberClient.Reply>>>(h => handler = h)
            .Returns(Task.CompletedTask);

        var messageHandlerMock = new Mock<IMessageHandler>();
        messageHandlerMock
            .Setup(m => m.Handle(It.IsAny<Message>()))
            .Callback<Message>(m => message = m)
            .Returns(Task.CompletedTask);

        var client = new GoogleSubscriberClient(
            subscriberMock.Object,
            SetupServiceProvider(messageHandlerMock.Object),
            Mock.Of<ILogger<GoogleSubscriberClient>>()
        );

        await client.StartAsync(CancellationToken.None);
        subscriberMock.Verify(m => m.StartAsync(It.IsAny<Func<PubsubMessage,CancellationToken,Task<SubscriberClient.Reply>>>()), Times.Once());

        var jsonMessage = new TestJsonMessage(
            Guid.NewGuid(),
            new TestJsonMessage.SubStructure(
                Guid.NewGuid(),
                "some-value"
            )
        );
        var msgId = Guid.NewGuid().ToString();
        var correlationId = Guid.NewGuid();
        var pubsubMessage = new PubsubMessage() {
            MessageId = msgId,
            Data = ByteString.CopyFrom(jsonMessage.Serialize().Data),
        };
        pubsubMessage.Attributes.Add("subject", "SomeSubjectName");
        pubsubMessage.Attributes.Add("correlation-id", correlationId.ToString());

        // Act
        await handler(pubsubMessage, CancellationToken.None);

        // Assert
        messageHandlerMock.Verify(m => m.Handle(It.IsAny<Message>()), Times.Once());
        message.Id.Should().Be(msgId);
        message.Subject.Should().Be("SomeSubjectName");
        message.CorrelationId.Should().Be(correlationId);
        TestJsonMessage.Deserialize(message).Should().BeEquivalentTo(jsonMessage);
    }

    private static IServiceProvider SetupServiceProvider(IMessageHandler messageHandler) {
        var services = new ServiceCollection();
        services.AddScoped(ctx => messageHandler);

        return services.BuildServiceProvider();
    }
}