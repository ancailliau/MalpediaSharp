using Newtonsoft.Json;

namespace MalpediaSharp;

public class Actor
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("common_name")] public string CommonName { get; set; }
    [JsonProperty("synonyms")] public List<string> Synonyms { get; set; }
}