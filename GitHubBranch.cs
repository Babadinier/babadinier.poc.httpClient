using System.Text.Json.Serialization;

namespace babadinier.poc.httpClient;

public record GitHubBranch([property: JsonPropertyName("name")] string Name);