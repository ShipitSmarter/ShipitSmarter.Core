using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Exceptions;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// A date range given in local datetime (without timezone information)
/// </summary>
public class LocalDateRange(DateTimeOffset start)
{
    /// <summary>
    /// The start of the date range
    /// </summary>
    [Required]
    public DateTimeOffset Start { get; set; } = start;

    private DateTimeOffset? _end;

    /// <summary>
    /// The end of the date range
    /// </summary>
    public DateTimeOffset? End
    {
        get => _end;
        set
        {
            if (value < Start)
            {
                throw new LogicException("Date Range End must be later than or equal to Start.");
            }
            _end = value;
        }
    }
}
