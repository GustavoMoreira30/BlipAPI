

using BlipAPI.Interfaces;
using BlipAPI.Models;

namespace BlipTeste.Service
{
  
  public class GitHubService : IGitHubService
  {
    private readonly IGitHubRepositories _gitHubRepositories;
    public GitHubService(IGitHubRepositories gitHubRepositories)
    {
      _gitHubRepositories = gitHubRepositories;
    }

    public async Task<IEnumerable<RespositoriesModel>> GetCSharpRepositoriesAsync()
    {
      var repos = await _gitHubRepositories.GetRepositoriesAsync("takenet");
      if (repos == null || !repos.Any())
      {
        return Enumerable.Empty<RespositoriesModel>();
      }
      var csRepos = repos
          .Where(r => r.Language == "C#")
          .OrderBy(r => r.CreatedAt)
          .Take(5)
          .Select(r => new RespositoriesModel
          {
            FullName = r.FullName,
            Description = r.Description,
            Image = r.User.Image
          });


      return csRepos;
    }
  }
}
