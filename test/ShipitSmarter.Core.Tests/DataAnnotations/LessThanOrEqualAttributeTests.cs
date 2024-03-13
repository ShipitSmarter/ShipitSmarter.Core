using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using ShipitSmarter.Core.DataAnnotations;

namespace ShipitSmarter.Core.Tests.DataAnnotations;

public class LessThanOrEqualAttributeTester
{
    public int MinIntProperty { get; set; }
    [LessThanOrEqual(nameof(MinIntProperty))]
    public int MaxIntProperty { get; set; }

    public decimal MinDecimalProperty { get; set; }
    [LessThanOrEqual(nameof(MinDecimalProperty))]
    public decimal MaxDecimalProperty { get; set; }

    public DateTime MinDateTimeProperty { get; set; }
    [LessThanOrEqual(nameof(MinDateTimeProperty))]
    public DateTime MaxDateTimeProperty { get; set; }
}

public class LessThanOrEqualAttributeTests
{
    [Fact]
    public void TryValidate_GreaterThan_ShouldReturnFalse()
    {
        var tester = new LessThanOrEqualAttributeTester()
        {
            MinIntProperty = 50,
            MaxIntProperty = 100,

            MinDecimalProperty = 25.5M,
            MaxDecimalProperty = 167.5M,

            MinDateTimeProperty = new(2023, 12, 11),
            MaxDateTimeProperty = new(2024, 1, 5),
        };

        var results = new List<ValidationResult>();
        var result = Validator.TryValidateObject(tester, new ValidationContext(tester), results, validateAllProperties: true);

        result.Should().BeFalse();
        results.Should().HaveCount(3);
    }

    [Fact]
    public void TryValidate_Equal_ShouldReturnTrue()
    {
        var tester = new LessThanOrEqualAttributeTester()
        {
            MinIntProperty = 50,
            MaxIntProperty = 50,

            MinDecimalProperty = 25.5M,
            MaxDecimalProperty = 25.5M,

            MinDateTimeProperty = new(2023, 12, 11),
            MaxDateTimeProperty = new(2023, 12, 11),
        };

        var result = Validator.TryValidateObject(tester, new ValidationContext(tester), [], validateAllProperties: true);

        result.Should().BeTrue();
    }

    [Fact]
    public void TryValidate_LessThan_ShouldReturnTrue()
    {
        var tester = new LessThanOrEqualAttributeTester()
        {
            MinIntProperty = 50,
            MaxIntProperty = 40,

            MinDecimalProperty = 25.5M,
            MaxDecimalProperty = 20.5M,

            MinDateTimeProperty = new(2023, 12, 11),
            MaxDateTimeProperty = new(2020, 10, 5),
        };

        var result = Validator.TryValidateObject(tester, new ValidationContext(tester), [], validateAllProperties: true);

        result.Should().BeTrue();
    }
}
