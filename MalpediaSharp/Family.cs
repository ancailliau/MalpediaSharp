using Newtonsoft.Json;

namespace MalpediaSharp;

public class Family
{
    [JsonProperty("name")] public string Name { get; set; }
    [JsonProperty("common_name")] public string CommonName { get; set; }
    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("alt_names")] public List<string> AltNames { get; set; }
    [JsonProperty("attribution")] public string Attribution { get; set; }
    [JsonProperty("library_entries")] public List<string> LibraryEntries { get; set; }
    [JsonProperty("notes")] public List<string> Notes { get; set; }
    [JsonProperty("sources")] public List<string> Sources { get; set; }
    [JsonProperty("urls")] public List<string> Urls { get; set; }
    [JsonProperty("updated")] public DateTime Updated { get; set; }
    [JsonProperty("uuid")] public string UUID { get; set; }
}