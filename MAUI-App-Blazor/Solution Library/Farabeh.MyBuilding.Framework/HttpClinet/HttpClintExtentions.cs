#nullable disable

using System.Web;

namespace Farabeh.MyBuilding.Framework.HttpClinet;

public static class HttpClintExtentions
{
    public static string ObjectToQueryString(this string url, object obj)
    {
        var props = obj.GetType().GetProperties();
        var param = new List<string>();
        foreach (var p in props)
        {
            var value = p.GetValue(obj, null);
            if (value != null)
            {
                string content = value.ToString();

                if (content.Contains("System.Collections.Generic.List`1[System.Int32]"))
                {
                    foreach (var item in value as List<int>)
                    {
                        param.Add(p.Name + "=" + HttpUtility.UrlEncode(item.ToString()));
                    }
                }

                else if (content.Contains("System.Collections.Generic.List`1[System.String]"))
                {
                    foreach (var item in value as List<string>)
                    {
                        param.Add(p.Name + "=" + HttpUtility.UrlEncode(item.ToString()));
                    }
                }


                else if (string.IsNullOrEmpty(content) == false)
                {
                    param.Add(p.Name + "=" + HttpUtility.UrlEncode(value.ToString()));
                }
            }
        }

        string queryString = String.Join("&", param);
        url += "?" + queryString;
        return url;
    }

    public static string GetIdFromQueryString(this string url)
    {
        var arrSegment = url.ToString().Split(new[] { "/" }, System.StringSplitOptions.RemoveEmptyEntries);
        return arrSegment[arrSegment.Length - 1];
    }
}
