using System.ComponentModel.DataAnnotations;
using ShipitSmarter.Core.Attributes;
using ShipitSmarter.Core.Exceptions;

namespace ShipitSmarter.Core.Models.v1;

/// <summary>
/// A date range given in absolute datetime (including timezone information)
/// </summary>
public class AbsoluteDateRange()
{
    /// <summary>
    /// The start of the date range
    /// </summary>
    [RequiredNotDefault]
    public DateTimeOffset Start { get; set; } = Defaults.DateTimeOffset;

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
