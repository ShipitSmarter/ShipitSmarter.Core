using System.Globalization;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace ShipitSmarter.Core.Serialization;


// from https://github.com/aaubry/YamlDotNet/issues/194#issuecomment-525732807
public class ObjectYamlTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(object);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            object value;
            if (parser.Current is Scalar scalar)
            {
                value = ParseScalar(scalar);
            }
            else
            {
                throw new InvalidOperationException(parser.Current?.ToString());
            }

            parser.MoveNext();
            return value;
        }

        private static object ParseScalar(Scalar scalar)
        {
            if (scalar.Value == null)
            {
                return null;
            }

            if (scalar.IsQuotedImplicit)
            {
                return scalar.Value;
            }

            if(string.IsNullOrEmpty(scalar.Value))
            {
                return null;
            }

            if (bool.TryParse(scalar.Value, out var booleanValue))
            {
                return booleanValue;
            }

            if (decimal.TryParse(scalar.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out var decimalValue))
            {
                return decimalValue;
            }

            if (DateTime.TryParse(scalar.Value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal,
                out var dateTimeValue))
            {
                return dateTimeValue;
            }
            
            return scalar.Value;
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            if (value == null)
            {
                emitter.Emit(new Scalar("tag:yaml.org,2002:null", ""));
                return;
            }

            if (value is object[] array)
            {
                emitter.Emit(new SequenceStart(null, null, false, SequenceStyle.Block));
                foreach (var element in array)
                {
                    WriteYaml(emitter, element, type);
                }

                emitter.Emit(new SequenceEnd());
                return;
            }

            switch (value)
            {
                case int intValue:
                    emitter.Emit(new Scalar(null, "tag:yaml.org,2002:int",
                        intValue.ToString(CultureInfo.InvariantCulture), ScalarStyle.Any, true, false));
                    break;
                case long longValue:
                    emitter.Emit(new Scalar(null, "tag:yaml.org,2002:int",
                        longValue.ToString(CultureInfo.InvariantCulture), ScalarStyle.Any, true, false));
                    break;
                case double doubleValue:
                    emitter.Emit(new Scalar(null, "tag:yaml.org,2002:float",
                        doubleValue.ToString(CultureInfo.InvariantCulture), ScalarStyle.Any, true, false));
                    break;
                case decimal decimalValue:
                    emitter.Emit(new Scalar(null, "tag:yaml.org,2002:float",
                        decimalValue.ToString(CultureInfo.InvariantCulture), ScalarStyle.Any, true, false));
                    break;
                case DateTime dateTimeValue:
                    emitter.Emit(new Scalar(null, "tag:yaml.org,2002:timestamp",
                        dateTimeValue.ToString(CultureInfo.InvariantCulture), ScalarStyle.Any, true, false));
                    break;
                case bool booleanValue:
                    emitter.Emit(new Scalar(null, "tag:yaml.org,2002:bool",
                        booleanValue.ToString(CultureInfo.InvariantCulture), ScalarStyle.Any, true, false));
                    break;
                case string stringValue:
                    emitter.Emit(new Scalar(null, "tag:yaml.org,2002:str", stringValue, ScalarStyle.Any, false, true));
                    break;
                default:
                    throw new InvalidOperationException(value.ToString());
            }
        }
    }