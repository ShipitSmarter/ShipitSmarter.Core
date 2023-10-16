using System.Text.Json;
using ShipitSmarter.Core.Converters;

namespace ShipitSmarter.Core.Tests.Converters;

public class MandatoryTimeZoneDateTimeOffsetConverterTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        Converters = { new MandatoryTimeZoneDateTimeOffsetConverter() }
    };

    [Fact]
    public void Read_WithDateTimeOffsetWithoutTimeZone_ThrowsJsonException()
    {
        var dateTimeString = "2021-09-01T00:00:00";
        
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TestClass>(Wrap(dateTimeString), _options));
        Assert.Equal("Time zone specification for DateTimeOffset is mandatory", exception.Message);
    }
    
    [Theory]
    [InlineData("2021-09-01T00:00:00+02:00", 2, "2021-09-01T00:00:00+02:00")]
    [InlineData("2021-09-01T00:00:00Z", 0, "2021-09-01T00:00:00+00:00")]
    public void Read_WithDateTimeOffsetWithTimeZone_ReturnsDateTimeOffset(string dateTimeString, int offSet, string expectedSerializedDateTimeOffset)
    {
        var expectedTimeSpan = offSet == 0 ? TimeSpan.Zero : TimeSpan.FromHours(offSet);
        var expectedDateTimeOffset = new DateTimeOffset(2021, 9, 1, 0, 0, 0, expectedTimeSpan);
        
        var testClass = JsonSerializer.Deserialize<TestClass>(Wrap(dateTimeString), _options);
        Assert.Equal(expectedDateTimeOffset, testClass!.DateTimeOffset);
        
        var backToString = JsonSerializer.Serialize(testClass, _options);
        Assert.Equal(Wrap(expectedSerializedDateTimeOffset), backToString);
    }

    private string Wrap(string dateTimeString)
    {
        return @"{""DateTimeOffset"":""" + dateTimeString + @"""}";
    }
    
    [Serializable]
    private record TestClass(DateTimeOffset DateTimeOffset);
}