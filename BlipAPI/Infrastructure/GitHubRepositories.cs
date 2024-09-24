using BlipAPI.Interfaces;
using BlipAPI.Models;
using Newtonsoft.Json;

namespace BlipAPI.Infrastructure
{
  public class GitHubRepositories : IGitHubRepositories
  {
    private readonly HttpClient _httpClient;

    public GitHubRepositories(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<IEnumerable<GitHubRepoResponse>> GetRepositoriesAsync(string organization)
    {
      var response = await _httpClient.GetAsync($"https://api.github.com/orgs/{organization}/repos");
      response.EnsureSuccessStatusCode();

      var content = await response.Content.ReadAsStringAsync();
      return JsonConvert.DeserializeObject<IEnumerable<GitHubRepoResponse>>(content);
    }
  }
}
