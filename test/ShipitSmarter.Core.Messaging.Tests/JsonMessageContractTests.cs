using System.Text.Json;
using FluentAssertions;
using Xunit.Sdk;

namespace ShipitSmarter.Core.Messaging.Tests;

public class JsonMessageContractTests
{
    [Fact]
    public void SerializeAndDeserialize_ResultsInSameMessage()
    {
        var orginalMessage = new TestJsonMessage(
            Guid.NewGuid(),
            new TestJsonMessage.SubStructure(
                Guid.NewGuid(),
                "some-value"
            )
        );

        var msg = orginalMessage.Serialize();

        var deserializedMessaged = TestJsonMessage.Deserialize(msg);

        deserializedMessaged.Should().BeEquivalentTo(orginalMessage);
    }

    [Fact]
    public void Serialize_AddsContentTypeAttribute() {
        var message = new TestJsonMessage(
            Guid.NewGuid(),
            new TestJsonMessage.SubStructure(
                Guid.NewGuid(),
                "some-value"
            )
        );

        var msg = message.Serialize();

        msg.Attributes.Should().Contain("Content-Type", "application/json");
    }

    [Fact]
    public void Serialize_SetsSubject() {
        var message = new TestJsonMessage(
            Guid.NewGuid(),
            new TestJsonMessage.SubStructure(
                Guid.NewGuid(),
                "some-value"
            )
        );

        var msg = message.Serialize();

        msg.Subject.Should().Be(TestJsonMessage.Subject);
    }

    [Fact]
    public void Deserialize_ThrowsWhenNull() {
        var json = JsonSerializer.SerializeToUtf8Bytes<TestMessage?>(null);
        var message = new Message("NullMessage", json);

        var deserialize = () => TestJsonMessage.Deserialize(message);
        
        deserialize.Should().Throw<MessageException>();
    }
}
