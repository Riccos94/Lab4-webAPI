using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using web_API;

HttpClient client = new()
{
    BaseAddress = new Uri("https://api.github.com/"),
    Timeout = TimeSpan.FromSeconds(30)
};

client.DefaultRequestHeaders.UserAgent.Add(
    new ProductInfoHeaderValue("web-API-demo", "1.0"));
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));


Console.WriteLine("Hämta alla repos");
var repos = await GetReposAsync(client);

for (int i = 0; i < 5 && i < repos.Count; i++)
{
    Console.WriteLine("------------------------------------------------");
    Console.WriteLine(repos[i]);
}



static async Task<List<Post>> GetReposAsync(HttpClient client)
{
    // GET https://api.github.com/orgs/dotnet/repos
    using Stream stream = await client.GetStreamAsync("orgs/dotnet/repos");
    var repos = await JsonSerializer.DeserializeAsync<List<Post>>(stream);
    return repos ?? new();
}


HttpClient zipClient = new()
{
    BaseAddress = new Uri("https://api.zippopotam.us/"),
    Timeout = TimeSpan.FromSeconds(30)
};

Console.WriteLine("\nMontvale, New Jersey:");
var zipInfo = await GetZipInfoAsync(zipClient, "us", "07645");
if (zipInfo != null)
{
    Console.WriteLine(zipInfo);
}


static async Task<ZipResponse?> GetZipInfoAsync(HttpClient client, string countryCode, string postalCode)
{
    try
    {
        using Stream stream = await client.GetStreamAsync($"{countryCode}/{postalCode}");
        var result = await JsonSerializer.DeserializeAsync<ZipResponse>(stream);
        return result;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Fel vid API-anrop: {ex.Message}");
        return null;
    }
}

Console.ReadKey();

