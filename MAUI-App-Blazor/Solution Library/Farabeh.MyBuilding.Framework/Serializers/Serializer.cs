#nullable disable

using Newtonsoft.Json;

namespace Farabeh.MyBuilding.Framework.Serializers;

public interface ISerializer
{
    T Deserialize<T>(string value);
    string Serialize<T>(object obj);
}
public class NewtonsoftJsonSerializer : ISerializer
{
    public T Deserialize<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }

    public string Serialize<T>(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}
