namespace DsvSerializerLib.Core;

public class DsvIgnoreAttribute : Attribute
{
    public bool IsIgnore { get; set; } = true;
}