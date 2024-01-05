#nullable disable

namespace Farabeh.MyBuilding.Api.Framework.ExtensionMethods.FileInfos;

public static class FileName
{
    public static string ToFilenameWithoutExtension(this string str, string extention)
    {
        return str.Replace(extention, "");
    }
}

