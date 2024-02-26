namespace ShipitSmarter.Core.Implementations;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class DateTimeResolver : IDateTimeResolver
{
    public DateTime Now => DateTime.Now;
    public DateTime Today => DateTime.Today;
}
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
