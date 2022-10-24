using Newtonsoft.Json;

namespace MalpediaSharp;

public class YaraRules
{
    [JsonProperty("tlp_white")] public List<Dictionary<string, string>> White { get; set; }
    [JsonProperty("tlp_green")] public List<Dictionary<string, string>> Green { get; set; }
    [JsonProperty("tlp_amber")] public List<Dictionary<string, string>> Amber { get; set; }
}