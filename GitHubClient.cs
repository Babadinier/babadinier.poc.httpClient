using System.Text.Json;

namespace babadinier.poc.httpClient;

public class GitHubClient : IGitHubClient
{
    private readonly IHttpClientFactory clientFactory;

    public GitHubClient(IHttpClientFactory clientFactory)
    {
        this.clientFactory = clientFactory;
    }

    public async Task<IEnumerable<GitHubBranch>> GetBranches(string url)
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            url);

        // Get the HttpClient define in Program.cs with the same name
        var httpClient = clientFactory.CreateClient("Github");
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        IEnumerable<GitHubBranch> gitHubBranches = new List<GitHubBranch>();
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream =
                await httpResponseMessage.Content.ReadAsStreamAsync();

            gitHubBranches = await JsonSerializer.DeserializeAsync
                <IEnumerable<GitHubBranch>>(contentStream);
        }

        return gitHubBranches;
    }
}