using System.ComponentModel;
using System.Reflection;

namespace OnlineCalculator.Extensions;

public static class EnumerationUtility
{
    public static string GetEnumDescription(Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());

        if (fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}