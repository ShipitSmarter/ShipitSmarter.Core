using System.Text.Json;
using FluentAssertions;
using Google.Cloud.PubSub.V1;
using Microsoft.Extensions.Logging;
using Moq;

namespace ShipitSmarter.Core.Messaging.Publisher.Tests;

public class GooglePublisherClientTests
{
    [Fact]
    public async Task Send_MapsMessageCorrectly()
    {
        // Arrange
        PubsubMessage publishedMessage = null!;

        var publisherMock = new Mock<PublisherClient>();
        publisherMock
            .Setup(m => m.PublishAsync(It.IsAny<PubsubMessage>()))
            .Callback<PubsubMessage>(m => publishedMessage = m)
            .ReturnsAsync(Guid.NewGuid().ToString());

        var correlationId = Guid.NewGuid();
        var correlatorMock = new Mock<ICorrelator>();
        correlatorMock.SetupGet(m => m.CurrentCorrelationId).Returns(correlationId);

        var client = new GooglePublisherClient(
            publisherMock.Object,
            correlatorMock.Object,
            Mock.Of<ILogger<GooglePublisherClient>>()
        );
        var message = new TestJsonMessage(
            Guid.NewGuid(),
            new TestJsonMessage.SubStructure(
                Guid.NewGuid(),
                "some-value"
            )
        );

        // Act
        await client.Publish(message);

        // Assert
        publisherMock.Verify(m => m.PublishAsync(It.IsAny<PubsubMessage>()), Times.Once());

        publishedMessage.Attributes.Should().Contain("subject", TestJsonMessage.Subject);
        publishedMessage.Attributes.Should().Contain("correlation-id", correlationId.ToString());
        var deserializedMessage = JsonSerializer.Deserialize<TestJsonMessage>(publishedMessage.Data.ToByteArray());
        deserializedMessage.Should().BeEquivalentTo(message);
    }
}
