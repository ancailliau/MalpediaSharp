using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MalpediaSharp;

public class MalpediaClient : IMalpediaClient {
    private const string BaseUrl = "https://malpedia.caad.fkie.fraunhofer.de/";
    private readonly HttpClient _httpClient;

    public MalpediaClient(string apiToken)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(BaseUrl);
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"apitoken {apiToken}");
    }
    
    public async Task<string> CheckApi()
    {
        var response = await _httpClient.GetAsync("/api/check/apikey");
        response.EnsureSuccessStatusCode();
        var stringAsync = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(stringAsync))
            throw new InvalidDataException();
        return JObject.Parse(stringAsync)["detail"].Value<string>();
    }

    private async Task<T> Get<T>(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var stringAsync = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(stringAsync))
            throw new InvalidDataException();
        return JsonConvert.DeserializeObject<T>(stringAsync);
    }
    
    public Task<List<Actor>> FindActor(string needle)
    {
        return Get<List<Actor>>($"/api/find/actor/{needle}");
    }

    public Task<List<Family>> FindFamily(string needle)
    {
        return Get<List<Family>>($"/api/find/family/{needle}");
    }

    public Task<ActorProfile> GetActor(string id)
    {
        return Get<ActorProfile>($"/api/get/actor/{id}");
    }

    public Task<Dictionary<string, Family>> GetFamilies(string? id = null)
    {
        if (string.IsNullOrEmpty(id))
            return Get<Dictionary<string, Family>>($"/api/get/families");
        else
            return Get<Dictionary<string, Family>>($"/api/get/families/{id}");
    }

    public Task<Family> GetFamily(string id)
    {
        return Get<Family>($"/api/get/family/{id}");
    }

    public Task<Dictionary<string, List<Reference>>> GetReferences()
    {
        return Get<Dictionary<string, List<Reference>>>($"/api/get/references");
    }

    public async Task<Stream> RawSample(string hash)
    {
        if (Regex.IsMatch(hash, "^[0-9a-fA-F]{32}$"))
        {
            var response = await _httpClient.GetAsync($"/api/get/sample/{hash}/raw");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }
        else if (Regex.IsMatch(hash, "^[0-9a-fA-F]{64}$"))
        {
            var response = await _httpClient.GetAsync($"/api/get/sample/{hash}/raw");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }
        else
        {
            throw new InvalidDataException();
        }
    }

    public async Task<Stream> ZipSample(string hash)
    {
        if (Regex.IsMatch(hash, "^[0-9a-fA-F]{32}$"))
        {
            var response = await _httpClient.GetAsync($"/api/get/sample/{hash}/zip");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }
        else if (Regex.IsMatch(hash, "^[0-9a-fA-F]{64}$"))
        {
            var response = await _httpClient.GetAsync($"/api/get/sample/{hash}/zip");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }
        else
        {
            throw new InvalidDataException();
        }
    }

    public Task<YaraRules> GetYara(string familyId)
    {
        return Get<YaraRules>($"/api/get/yara/{familyId}");
    }

    public async Task<Stream> GetYaraZip(string familyId)
    {
        var response = await _httpClient.GetAsync($"/api/get/yara/{familyId}/zip");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStreamAsync();
    }

    public Task<List<string>> ListActors()
    {
        return Get<List<string>>($"/api/list/actors");
    }

    public Task<List<string>> ListFamilies()
    {
        return Get<List<string>>($"/api/list/families");
    }

    public Task<Dictionary<string, SampleOverview>> ListSamples(string? familyId = null)
    {
        if (string.IsNullOrEmpty(familyId))
            return Get<Dictionary<string, SampleOverview>>($"/api/list/samples");
        else
            return Get<Dictionary<string, SampleOverview>>($"/api/list/samples/{familyId}");
    }
}