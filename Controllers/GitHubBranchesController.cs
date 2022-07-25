using Microsoft.AspNetCore.Mvc;

namespace babadinier.poc.httpClient.Controllers;

[ApiController]
[Route("[controller]")]
public class GitHubController : ControllerBase
{
    private readonly IGitHubClient gitHubClient;
    private readonly ILogger<GitHubController> logger;

    public GitHubController(IGitHubClient gitHubClient, 
        ILogger<GitHubController> logger)
    {
        this.logger = logger;
        this.gitHubClient = gitHubClient;
    }

    [HttpGet("branches")]
    public async Task<IEnumerable<GitHubBranch>> Get()
    {
        return await gitHubClient.GetBranches(
            "https://api.github.com/repos/dotnet/AspNetCore.Docs/branches");
    }
}
