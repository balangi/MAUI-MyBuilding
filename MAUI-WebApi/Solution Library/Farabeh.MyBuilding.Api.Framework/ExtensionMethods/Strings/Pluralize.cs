#nullable disable

namespace Farabeh.MyBuilding.Api.Framework.ExtensionMethods.Strings;

public static class Pluralize
{
    public static string ToPluralize(this string str)
    {
        var suffix = "s";

        if (str.EndsWith('y'))
        {
            suffix = "ies";
            return $"{str[..^1]}{suffix}";
        }

        if (str.EndsWith('s'))
        {
            suffix = "ses";
            return $"{str[..^1]}{suffix}";
        }

        return $"{str}{suffix}";
    }
}

