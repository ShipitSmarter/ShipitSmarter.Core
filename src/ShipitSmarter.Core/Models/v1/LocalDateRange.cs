using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Attributes;
using ShipitSmarter.Core.Exceptions;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// A date range given in local datetime (without timezone information)
/// </summary>
public class LocalDateRange()
{
    /// <summary>
    /// The start of the date range
    /// </summary>
    [RequiredNotDefault]
    public DateTime Start { get; set; } = Defaults.DateTime;

    private DateTime? _end;

    /// <summary>
    /// The end of the date range
    /// </summary>
    public DateTime? End
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
