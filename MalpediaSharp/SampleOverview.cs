using Newtonsoft.Json;

namespace MalpediaSharp;

public class SampleOverview
{
    [JsonProperty("sha256")] public string Sha256 { get; set; }
    [JsonProperty("version")] public string Version { get; set; }
    [JsonProperty("status")] public string Status { get; set; }
}