using BlipAPI.Models;

namespace BlipAPI.Interfaces
{
    public interface IGitHubService
    {
    Task<IEnumerable<RespositoriesModel>> GetCSharpRepositoriesAsync();
    }

}