namespace MalpediaSharp;

public interface IMalpediaClient
{
    Task<string> CheckApi();
    Task<List<Actor>> FindActor(string needle);
    Task<List<Family>> FindFamily(string needle);
    Task<ActorProfile> GetActor(string id);
    Task<Dictionary<string,Family>> GetFamilies(string id);
    Task<Family> GetFamily(string id);
    Task<Dictionary<string, List<Reference>>> GetReferences();
    
    Task<Stream> RawSample(string hash);
    Task<Stream> ZipSample(string hash);

    Task<YaraRules> GetYara(string familyId);
    Task<Stream> GetYaraZip(string familyId);

    Task<List<string>> ListActors();
    Task<List<string>> ListFamilies();
    Task<Dictionary<string,SampleOverview>> ListSamples(string familyId = null);
}