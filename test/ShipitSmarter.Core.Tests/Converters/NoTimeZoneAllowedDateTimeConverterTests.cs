using System.Text.Json;
using ShipitSmarter.Core.Converters;

namespace ShipitSmarter.Core.Tests.Converters;

public class NoTimeZoneAllowedDateTimeConverterTests
{
    private readonly JsonSerializerOptions _options = new()
    {
        Converters = { new NoTimeZoneAllowedDateTimeConverter() }
    };

    [Theory]
    [InlineData("2021-09-01T00:00:00+02:00")]
    [InlineData("2021-09-01T00:00:00Z")]
    public void Read_WithDateTimeWithTimeZone_ThrowsJsonException(string dateTimeString)
    {
        var exception = Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TestClass>(Wrap(dateTimeString), _options));
        Assert.Equal("Time zone specification for DateTime is not allowed", exception.Message);
    }
    
    [Fact]
    public void Read_WithDateTimeWithUtcTimeZone_ReturnsDateTime()
    {
        var dateTimeString = "2021-09-01T00:00:00";
        
        var testClass = JsonSerializer.Deserialize<TestClass>(Wrap(dateTimeString), _options);
        Assert.Equal(new DateTime(2021, 9, 1, 0, 0, 0, DateTimeKind.Utc), testClass!.DateTime);
        
        var backToString = JsonSerializer.Serialize(testClass, _options);
        Assert.Equal(Wrap(dateTimeString), backToString);
    }
    
    private string Wrap(string dateTimeString)
    {
        return @"{""DateTime"":""" + dateTimeString + @"""}";
    }
    
    [Serializable]
    private record TestClass(DateTime DateTime);
}