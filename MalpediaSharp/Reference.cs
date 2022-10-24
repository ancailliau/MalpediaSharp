using Newtonsoft.Json;

namespace MalpediaSharp;

public class Reference
{
    [JsonProperty("type")] public string Type { get; set; }
    [JsonProperty("id")] public string ID { get; set; }
    [JsonProperty("common_name")] public string CommonName { get; set; }
    [JsonProperty("alt_names")] public string AltNames { get; set; }
    [JsonProperty("url")] public string URL { get; set; }
}