using FluentAssertions;
using Moq;
using ShipitSmarter.Core.Secrets;
using ShipitSmarter.Core.Serialization.Secrets;

namespace ShipitSmarter.Core.Tests.Serialization;

public class SecretConfigFileManagerTests
{
    private readonly SecretConfigFileManager _sut;
    private readonly MockFileHandling _fileHandling = new();
    
    private readonly TestableConfiguration _config = new()
    {
        Username = "henk",
        SomeDate = new DateTime(2030, 11, 23),
        OtherSecret = new SecretValue<int>(42),
        Password = new SecretValue<string>("biggest-secret-ever")
    };

    public SecretConfigFileManagerTests()
    {
        _sut = new SecretConfigFileManager(_fileHandling);
    }

    [Fact]
    public void WritesSecretsToSeparateFiles_AsJson()
    {
        _sut.WriteToDisk(_config, "testable.json");

        AssertFileWithContents("testable.json",
            """
            {"username":"henk","someDate":"2030-11-23T00:00:00"}
            """);
            
        AssertFileWithContents("testable.Password.enc.json",
            """
            {"password":"biggest-secret-ever"}
            """);
        
        AssertFileWithContents("testable.OtherSecret.enc.json",
            """
            {"otherSecret":42}
            """);
    }
    
    [Fact]
    public void WritesSecretsToSeparateFilesOnlyWhenChanged_AsJson()
    {
        _config.Password.Set("newPassword");
        _sut.WriteToDiskSecretsOnlyWhenUpdated(_config, "testable.json");

        AssertFileWithContents("testable.json",
            """
            {"username":"henk","someDate":"2030-11-23T00:00:00"}
            """);

        AssertFileWithContents("testable.Password.enc.json",
            """
            {"password":"newPassword"}
            """);
        
        AssertFileNotExists("testable.OtherSecret.enc.yaml");
    }

    

    [Fact]
    public void WritesSecretsToSeparateFiles_AsYaml()
    {
        _sut.WriteToDisk(_config, "testable.yaml");

        AssertFileWithContents("testable.yaml",
            """
            username: henk
            someDate: 2030-11-23T00:00:00
            
            """);
            
        AssertFileWithContents("testable.Password.enc.yaml",
            """
            password: biggest-secret-ever
            
            """);
        
        AssertFileWithContents("testable.OtherSecret.enc.yaml",
            """
            otherSecret: 42
            
            """);
    }

    [Fact]
    public void ReadsSecretsToSeparateFiles_AsJson()
    {
        var fs = new MockFileHandling(new Dictionary<string, string>
        {
            { "testable.json", new("""{"username":"henk","someDate":"2030-11-23T00:00:00"}""") },
            { "testable.Password.enc.json", new("""{"password":"biggest-secret-ever"}""") },
            { "testable.OtherSecret.enc.json", new("""{"otherSecret":42}""") },
        });
        var sut = new SecretConfigFileManager(fs);

        var configFromFiles = sut.ReadFromDisk<TestableConfiguration>("testable.json");

        configFromFiles.Should().BeEquivalentTo(_config);
    }
    
    [Fact]
    public void ReadsSecretsToSeparateFiles_AsYaml()
    {
        var fs = new MockFileHandling(new Dictionary<string, string>
        {
            { "testable.yaml", new("""
                                   username: henk
                                   someDate: 2030-11-23T00:00:00
                                   """) },
            { "testable.Password.enc.yaml", new("""password: biggest-secret-ever""") },
            { "testable.OtherSecret.enc.yaml", new("""otherSecret: 42""") },
        });
        var sut = new SecretConfigFileManager(fs);

        var configFromFiles = sut.ReadFromDisk<TestableConfiguration>("testable.yaml");

        configFromFiles.Should().BeEquivalentTo(_config);
    }

    private void AssertFileWithContents(string expectedFilename, string expectedContents)
    {
        var fileExists = _fileHandling.Exists(expectedFilename);
        fileExists.Should().BeTrue();
        var contents = _fileHandling.ReadAllText(expectedFilename);
        contents.Should().Be(expectedContents);
    }
    
    private void AssertFileNotExists(string filename)
    {
        var fileExists = _fileHandling.Exists(filename);
        fileExists.Should().BeFalse();
    }
    
    public class TestableConfiguration
    {
        public string Username { get; set; }
        public DateTime SomeDate { get; set; }
        public SecretValue<string> Password { get; set; }
        public SecretValue<int> OtherSecret { get; set; }
    }
}