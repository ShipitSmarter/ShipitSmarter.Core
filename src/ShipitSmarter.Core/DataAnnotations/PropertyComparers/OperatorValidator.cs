namespace ShipitSmarter.Core.DataAnnotations;

internal class OperatorValidator
{
    public string ErrorMessage { get; internal set; } = string.Empty;
    public Func<object, object, bool> IsValid { get; internal set; } = (_, _) => true;

    static OperatorValidator()
    {
        InitialiseOperators();
    }

    public static Dictionary<Operator, OperatorValidator> Operators = [];

    private static void InitialiseOperators()
    {
        Operators = new Dictionary<Operator, OperatorValidator>()
        {
            { Operator.GreaterThan, new OperatorValidator()
                {
                    ErrorMessage = "greater than",
                    IsValid = (value, dependentValue) => {
                        if (value is null || dependentValue is null)
                            return false;
                        return Compare(value, dependentValue) >= 1;
                    }
                }
            },

            { Operator.GreaterThanOrEqualTo, new OperatorValidator()
                {
                    ErrorMessage = "greater than or equal to",
                    IsValid = (value, dependentValue) => {
                        if (value is null && dependentValue is null)
                            return true;
                        if (value is null || dependentValue is null)
                            return false;
                        return Compare(value, dependentValue) >= 0;
                    }
                }
            },

            { Operator.LessThan, new OperatorValidator()
                {
                    ErrorMessage = "less than",
                    IsValid = (value, dependentValue) => {
                        if (value is null || dependentValue is null)
                            return false;
                        return Compare(value, dependentValue) <= -1;
                    }
                }
            },

            { Operator.LessThanOrEqualTo, new OperatorValidator()
                {
                    ErrorMessage = "less than or equal to",
                    IsValid = (value, dependentValue) => {
                        if (value is null && dependentValue is null)
                            return true;
                        if (value is null || dependentValue is null)
                            return false;
                        return Compare(value, dependentValue) <= 0;
                    }
                }
            },
        };
    }

    private static int Compare(object value, object dependentValue)
    {
        var comparableValue = (IComparable)value;
        var comparableDependentValue = (IComparable)dependentValue;

        return comparableValue.CompareTo(comparableDependentValue);
    }
}
