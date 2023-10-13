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
    
    [Fact]
    public void Read_WithDateTimeOffsetWithTimeZone_ReturnsDateTimeOffset()
    {
        var dateTimeString = "2021-09-01T00:00:00+02:00";
        
        var testClass = JsonSerializer.Deserialize<TestClass>(Wrap(dateTimeString), _options);
        Assert.Equal(new DateTimeOffset(2021, 9, 1, 0, 0, 0, TimeSpan.FromHours(2)), testClass!.DateTimeOffset);
        
        var backToString = JsonSerializer.Serialize(testClass, _options);
        Assert.Equal(Wrap(dateTimeString), backToString);
    }
    
    [Fact]
    public void Read_WithDateTimeOffsetWithUtcTimeZone_ReturnsDateTimeOffset()
    {
        var dateTimeString = "2021-09-01T00:00:00Z";
        
        var testClass = JsonSerializer.Deserialize<TestClass>(Wrap(dateTimeString), _options);
        Assert.Equal(new DateTimeOffset(2021, 9, 1, 0, 0, 0, TimeSpan.Zero), testClass!.DateTimeOffset);
        
        var backToString = JsonSerializer.Serialize(testClass, _options);
        Assert.Equal(Wrap(dateTimeString), backToString);
    }

    private string Wrap(string dateTimeString)
    {
        return @"{""DateTimeOffset"":""" + dateTimeString + @"""}";
    }
    
    [Serializable]
    private record TestClass(DateTimeOffset DateTimeOffset);
}