using BlipAPI.Models;


namespace BlipAPI.Interfaces
{
  public interface IGitHubRepositories
  {
    Task<IEnumerable<GitHubRepoResponse>> GetRepositoriesAsync(string organization);
  }
}
