namespace babadinier.poc.httpClient;

public interface IGitHubClient
{
    Task<IEnumerable<GitHubBranch>> GetBranches(string url);
}
