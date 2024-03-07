using Ardalis.SmartEnum;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace ShipitSmarter.Core.Serialization;

/// <summary>
/// Yaml type converter for <see cref="SmartEnum{TEnum, TValue}"/> based on the <see cref="Ardalis.SmartEnum.SmartEnum{TEnum, TValue}.Name"/>
/// </summary>
public class SmartEnumFromNameYamlTypeConverter : IYamlTypeConverter
{
    /// <inheritdoc />
    public bool Accepts(Type type)
    {
        return typeof(ISmartEnum).IsAssignableFrom(type);
    }

    /// <inheritdoc />
    public object? ReadYaml(IParser parser, Type type)
    {
        object? value;
        if (parser.Current is Scalar scalar)
        {
            var strValue = scalar.Value;
            var genericArgs = type.BaseType!.GetGenericArguments();
            var constructed = typeof(SmartEnum<,>).MakeGenericType(genericArgs);
            var method = constructed.GetMethod("FromName");
            if (method == null)
            {
                throw new InvalidOperationException($"Method 'FromName' not found on type: {type.FullName}");
            }
            value = method.Invoke(null, new object[] { strValue.ToUpper(), false });
        }
        else
        {
            throw new InvalidOperationException(parser.Current?.ToString());
        }
        
        parser.MoveNext();
        return value;
    }

    /// <inheritdoc />
    public void WriteYaml(IEmitter emitter, object? value, Type type)
    {
        throw new NotImplementedException("This functionality is not implemented, because when writing Yaml we always first convert to JSON!");
    }
}