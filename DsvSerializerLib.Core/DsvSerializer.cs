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
            var attribute = property.GetCustomAttribute<DsvIgnoreAttribute>();
            if (attribute is not null &&  attribute.IsIgnore)
            {
                continue;
            }
            
            stringBuilder.Append($"{property.GetValue(obj)}{delimiter}");
        }

        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }
}