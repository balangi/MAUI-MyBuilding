namespace Farabeh.MyBuilding.Framework.HttpClinet;

public static class Extentions
{
    public static string GuidListToString(this List<Guid> guidCollection, string seprator = ",")
    {
        return string.Join(seprator, guidCollection.Select(g => g.ToString()).ToArray());
    }
}
