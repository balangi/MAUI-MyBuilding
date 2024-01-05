#nullable disable

namespace Farabeh.MyBuilding.Api.Framework.ExtensionMethods.TypeInfos;

public static class ObjectHelper
{
    public static object GetPropValue(this object src, string propName)
    {
        if (src.GetType().GetProperty(propName) == null)
        {
            return null;
        }
        return src.GetType().GetProperty(propName).GetValue(src, null);
    }
}
