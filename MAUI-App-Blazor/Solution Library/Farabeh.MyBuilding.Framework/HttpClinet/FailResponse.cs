#nullable disable

using Newtonsoft.Json;

namespace Farabeh.MyBuilding.Framework.HttpClinet;

public class FailResponse
{
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("title")]
    public string Title { get; set; }
    [JsonProperty("status")]
    public int Status { get; set; }
    [JsonProperty("traceId")]
    public string TraceId { get; set; }
    [JsonProperty("errors")]
    public Dictionary<string, string[]> Errors { get; set; }
}
