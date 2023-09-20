namespace DsvSerializerLib.Core;

public enum DateTimeMode
{
    Date, Time, DateTime
}

public class DateTimeAttribute : Attribute
{
    public DateTimeMode Mode { get; set; }

    public DateTimeAttribute(DateTimeMode mode)
    {
        Mode = mode;
    }
}