using System.Reflection;
using System.Text;

namespace DsvSerializerLib.Core;

public static class DsvSerializer
{
    public static string Serialize(object obj, char delimiter = '|')
    {
        var type = obj.GetType();

        var stringBuilder = new StringBuilder();
        foreach (var property in type.GetProperties())
        {
            Attribute? attribute = property.GetCustomAttribute<DsvIgnoreAttribute>();
            
            /*
            if (attribute is not null)
            {
                if (attribute is DsvIgnoreAttribute)
                {
                    var a = (DsvIgnoreAttribute)attribute;
                    if (a.IsIgnore)
                    {
                        continue;
                    }
                }
            }
             */
            
            if (attribute is DsvIgnoreAttribute { IsIgnore: true }) continue;

            attribute = property.GetCustomAttribute<DateTimeAttribute>();
            if (attribute is DateTimeAttribute dateTimeAttribute)
            {
                var date = property.GetValue(obj) is DateTime ? (DateTime)property.GetValue(obj) : default;
                switch (dateTimeAttribute.Mode)
                {
                    case DateTimeMode.Date:
                        stringBuilder.Append($"{date:d}{delimiter}");
                        break;
                    case DateTimeMode.Time:
                        stringBuilder.Append($"{date:t}{delimiter}");
                        break;
                    case DateTimeMode.DateTime:
                        stringBuilder.Append($"{date:g}{delimiter}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(DateTimeAttribute));
                }
                continue;
            }
            
            stringBuilder.Append($"{property.GetValue(obj)}{delimiter}");
        }

        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }
}