using System.Text.Json;
using FluentAssertions;
using ShipitSmarter.Core.Secrets;
using ShipitSmarter.Core.Serialization.Constants;

namespace ShipitSmarter.Core.Tests.Serialization;

public class SecretValueTests
{
    [Fact]
    public void CanSerializeAndDeserialize()
    {
        var secret = new SecretValue("enc", "key1");
        var json = JsonSerializer.Serialize(secret, JsonSerializationConstants.Options);

        json.Should().Be("""{"encryptedData":"enc","updated":false,"keyId":"key1"}""");

        var deserialized = JsonSerializer.Deserialize<SecretValue>(json, JsonSerializationConstants.Options);
        deserialized.Should().BeEquivalentTo(secret);
    }
}