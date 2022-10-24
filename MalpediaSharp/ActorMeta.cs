using Newtonsoft.Json;

namespace MalpediaSharp;

public class ActorMeta
{
    [JsonProperty("attribution-confidence")] public string AttributionConfidence { get; set; }
    [JsonProperty("cfr-suspected-state-sponsor")] public string SuspectedStateSponsor { get; set; }
    [JsonProperty("cfr-suspected-victims")] public List<string> SuspectedVictims { get; set; }
    [JsonProperty("cfr-target-category")] public List<string> TargetCategory { get; set; }
    [JsonProperty("cfr-type-of-incident")] public string TypeOfIncident { get; set; }
    [JsonProperty("country")] public string Country { get; set; }
    [JsonProperty("refs")] public List<string> Refs { get; set; }
    [JsonProperty("synonyms")] public List<string> Synonyms { get; set; }
}