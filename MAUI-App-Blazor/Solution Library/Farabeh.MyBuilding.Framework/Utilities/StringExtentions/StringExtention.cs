#nullable disable

namespace Farabeh.MyBuilding.Framework.Utilities.StringExtentions;

public static class StringExtention
{
    public static TSelf TrimStringProperties<TSelf>(this TSelf input)
    {
        var stringProperties = input.GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(string) && p.CanWrite);

        foreach (var stringProperty in stringProperties)
        {
            string currentValue = (string)stringProperty.GetValue(input, null);
            if (currentValue != null)
                stringProperty.SetValue(input, currentValue.Trim(), null);
        }
        return input;
    }
}
