using Newtonsoft.Json;

namespace MalpediaSharp;

public class ActorProfile   
{
    [JsonProperty("value")] public string Name { get; set; }
    [JsonProperty("uuid")] public string UUID { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("meta")] public ActorMeta Meta { get; set; }
    [JsonProperty("families")] public Dictionary<string,Family> Families { get; set; }
}