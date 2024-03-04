using System.Reflection;
using System.Text.Json;
using ShipitSmarter.Core.Secrets;
using ShipitSmarter.Core.Serialization.Constants;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace ShipitSmarter.Core.Serialization.Secrets;

public class SecretConfigFileManager : ISecretConfigFileReader, ISecretConfigFileWriter
{
    private const string JsonExtension = ".json";
    private const string YamlExtension = ".yaml";
    
    private readonly IFileHandling _fileHandling;
    
    private readonly ISerializer _yamlSerializer = new SerializerBuilder()
        .WithQuotingNecessaryStrings()
        .WithTypeConverter(new ObjectYamlTypeConverter())
        .Build();
    
    private readonly IDeserializer _yamlDeserializer = new DeserializerBuilder()
        .IgnoreUnmatchedProperties()
        .WithNamingConvention(CamelCaseNamingConvention.Instance)
        .WithTypeConverter(new ObjectYamlTypeConverter())
        // TODO add generic smartenum converter .WithTypeConverter(new FtpConnectionTypeYamlConverter())
        .Build();

    public SecretConfigFileManager(IFileHandling fileHandling)
    {
        _fileHandling = fileHandling;
    }
    
    public T ReadFromDisk<T>(string filepath)
    {
        var (parent, filenameWithoutExtension, extension) = SplitPath(filepath);
        
        var contents = _fileHandling.ReadAllText(Path.Combine(parent, $"{filenameWithoutExtension}{extension}"));
        var obj = Deserialize<T>(contents, extension);

        var secretProps = GetSecrets(obj);
        foreach (var secretProp in secretProps)
        {
            var secretFilename = Path.Combine(parent, $"{filenameWithoutExtension}.{secretProp.Name}.enc{extension}");
            if (!_fileHandling.Exists(secretFilename))
            {
                throw new SecretException($"Expected file '{secretFilename}' to exist");
            }
            
            contents = _fileHandling.ReadAllText(secretFilename);
            var secretValue = DeserializeSecret(secretProp, contents, secretFilename, extension);
            secretProp.SetValue(obj, secretValue);
        }

        return obj!;
    }

    public void WriteToDisk<T>(T obj, string filepath)
    {
        WriteToDiskInternal(obj, filepath, alwaysWriteSecrets: true);
    }
    
    public void WriteToDiskSecretsOnlyWhenUpdated<T>(T obj, string filepath)
    {
        WriteToDiskInternal(obj, filepath, alwaysWriteSecrets: false);
    }

    private void WriteToDiskInternal<T>(T obj, string filepath, bool alwaysWriteSecrets)
    {
        var (parent, filenameWithoutExtension, extension) = SplitPath(filepath);
        // Write the none secrets to file
        var contents = Serialize(obj, extension);
        _fileHandling.WriteAllText(Path.Combine(parent, $"{filenameWithoutExtension}{extension}"), contents);
        
        // Write each secret to it's own file
        var secretProps = GetSecrets(obj);
        foreach (var secretProp in secretProps)
        {
            var secretValueObj = secretProp.GetValue(obj) as ISecretValue;
            if (alwaysWriteSecrets == false && secretValueObj?.Updated == false)
            {
                continue;
            }
            
            var secretObj = new Dictionary<string, object?>{ [ToCamelCase(secretProp.Name)] = secretValueObj!.GetValue() };
            contents = Serialize(secretObj, extension);
            _fileHandling.WriteAllText(Path.Combine(parent, $"{filenameWithoutExtension}.{secretProp.Name}.enc{extension}"), contents);
        }
    }

    private static PropertyInfo[] GetSecrets<T>(T _)
    {
        return typeof(T).GetProperties()
            .Where(p => typeof(ISecretValue).IsAssignableFrom(p.PropertyType))
            .ToArray();
    }
    
    private string Serialize<T>(T obj, string extension)
    {
        return extension switch
        {
            JsonExtension => SerializeToJson(obj),
            YamlExtension => SerializeToYaml(obj),
            _ => throw new ArgumentException($"Extension {extension} not supported", nameof(extension))
        };
    }
    
    private T Deserialize<T>(string contents, string extension)
    {
        return extension switch
        {
            JsonExtension => DeserializeFromJson<T>(contents),
            YamlExtension => DeserializeFromYaml<T>(contents),
            _ => throw new ArgumentException($"Extension {extension} not supported", nameof(extension))
        };
    }
    
    private ISecretValue DeserializeSecret(PropertyInfo secretProp, string contents, string secretFilename, string extension)
    {
        return extension switch
        {
            JsonExtension => DeserializeSecretFromJson(secretProp, contents, secretFilename),
            YamlExtension => DeserializeSecretFromYaml(secretProp, contents, secretFilename),
            _ => throw new ArgumentException($"Extension {extension} not supported", nameof(extension))
        };
    }
    
    private string SerializeToJson<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, JsonSerializationConstants.Options);
    }

    private T DeserializeFromJson<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, JsonSerializationConstants.Options) ?? throw new ArgumentException("Deserialize json '{json}' resulted in null", nameof(json));
    }
    
    private string SerializeToYaml<T>(T obj)
    {
        var jsonDoc = JsonSerializer.SerializeToDocument(obj, JsonSerializationConstants.Options);
        var jsonObj = jsonDoc.RootElement.ConvertToObject();
        return _yamlSerializer.Serialize(jsonObj);
    }
    
    private T DeserializeFromYaml<T>(string yaml)
    {
        using var reader = new StringReader(yaml);
        return _yamlDeserializer.Deserialize<T>(reader);
    }
    
    private ISecretValue DeserializeSecretFromYaml(PropertyInfo secretProp, string contents, string secretFilename)
    {
        var yamlObject = _yamlDeserializer.Deserialize(contents);
        var serializer = new SerializerBuilder()
            .JsonCompatible()
            .Build();

        var json = serializer.Serialize(yamlObject);
        return DeserializeSecretFromJson(secretProp, json, secretFilename);
    }

    private ISecretValue DeserializeSecretFromJson(PropertyInfo secretProp, string contents, string secretFilename)
    {
        var jsonDoc = JsonDocument.Parse(contents);

        try
        {
            var prop = jsonDoc.RootElement.GetProperty(ToCamelCase(secretProp.Name));
            var secretValueType = secretProp.PropertyType.GetGenericArguments()[0];
            var constructed = typeof(SecretValue<>).MakeGenericType(secretValueType);
            var deserializedProp = prop.Deserialize(secretValueType);
            if (deserializedProp == null)
            {
                throw new SecretException($"Cannot deserialize '{secretProp.Name}' from file '{secretFilename}'");
            }
            var secretValue = Activator.CreateInstance(constructed, deserializedProp) as ISecretValue;
            if (secretValue == null)
            {
                throw new SecretException($"Cannot create secret '{secretProp.Name}' from file '{secretFilename}'");
            }

            return secretValue;
        }
        catch (KeyNotFoundException)
        {
            throw new SecretException(
                $"Expected '{secretProp.Name}' in file '{secretFilename}'");
        }
    }
    
    private static string ToCamelCase(string name)
    {
        if (string.IsNullOrEmpty(name) || !char.IsUpper(name[0]))
        {
            return name;
        }

        return char.ToLower(name[0]) + name[1..];
    }

    private static (string parentPath, string filenameWithoutExtension, string extension) SplitPath(string filepath)
    {
        return (
            Path.GetDirectoryName(filepath) ?? string.Empty,
            Path.GetFileNameWithoutExtension(filepath),
            Path.GetExtension(filepath)
        );
    }
}