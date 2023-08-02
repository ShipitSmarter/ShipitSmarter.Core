using FluentAssertions;
using ShipitSmarter.Core.Implementations;

namespace ShipitSmarter.Core.Tests;

public class GlobberTests
{
    private static readonly string TestPath = Path.Join("TestFiles", "some", "dir");
    private readonly Globber _sut = new();
    
    [Fact]
    public void GetAbsolutePathsFromGlobPattern_WhenGeneral_ShouldReturnMultipleFiles()
    {
        const string globPattern = "*.json";
        var expected = new List<string>
        {
            Path.Join(TestPath,"booking.integration.json"),
            Path.Join(TestPath,"booking.schema.json"),
            Path.Join(TestPath,"booking.uischema.json")
        };
        
        var result = _sut.GetAbsoluteFilePathsFromGlobPattern(TestPath, globPattern);
        
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void GetAbsolutePathsFromGlobPattern_WhenSpecific_ShouldReturnSingleFile()
    {
        const string globPattern = "booking*.integration.json";
        var expected = new List<string>
        {
            Path.Join(TestPath, "booking.integration.json")
        };
        
        var result = _sut.GetAbsoluteFilePathsFromGlobPattern(TestPath, globPattern);
        
        result.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void GetAbsolutePathsFromGlobPattern_WhenNoFiles_ShouldReturnEmptyList()
    {
        const string globPattern = "booking*.bla.json";
        
        var result = _sut.GetAbsoluteFilePathsFromGlobPattern(TestPath, globPattern);

        result.Should().BeEmpty();
    }

    [Fact]
    public void GetRelativePathsFromGlobPattern_ShouldReturnWithRelativePaths()
    {
        const string relativePath = "some";
        const string globPattern = "*.json";
        var expected = new List<string>
        {
            Path.Join(relativePath, "booking.integration.json"),
            Path.Join(relativePath, "booking.schema.json"),
            Path.Join(relativePath, "booking.uischema.json")
        };
        
        var result = _sut.GetRelativeFilePathsFromGlobPattern(relativePath, TestPath, globPattern);
        
        result.Should().BeEquivalentTo(expected);
    }
}