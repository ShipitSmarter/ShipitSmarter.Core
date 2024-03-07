using FluentAssertions;
using ShipitSmarter.Core.Enumerations.v1;
using ShipitSmarter.Core.Serialization;
using YamlDotNet.Serialization;

namespace ShipitSmarter.Core.Tests.Serialization;

public class SmartEnumFromNameYamlTypeConverterTests
{
    [Fact]
    public void CanDeserialize()
    {
        var deserializer = new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .WithTypeConverter(new SmartEnumFromNameYamlTypeConverter())
            .Build();

        var yaml = """
                   FtpConnection: FTPS
                   CountryCode: DE
                   """;
        
        var result = deserializer.Deserialize<TestClassWithSmartEnums>(new StringReader(yaml));
        result.FtpConnection.Should().Be(FtpConnectionType.FTPS);
        result.CountryCode.Should().Be(CountryCode.DE);
    }

    private class TestClassWithSmartEnums
    {
        public FtpConnectionType FtpConnection { get; set; } = FtpConnectionType.SFTP;
        public CountryCode CountryCode { get; set; } = CountryCode.AD;
    }
}