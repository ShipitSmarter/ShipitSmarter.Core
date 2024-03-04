using ShipitSmarter.Core.Secrets;

namespace ShipitSmarter.Core.Tests.Serialization;

public class MockFileHandling(IDictionary<string, string> files) : IFileHandling
{
    public MockFileHandling() : this(new Dictionary<string, string>())
    {
    }
    
    public bool Exists(string path)
    {
        return files.ContainsKey(path);
    }

    public string ReadAllText(string path)
    {
        return files[path];
    }

    public void WriteAllText(string path, string contents)
    {
        files[path] = contents;
    }
}