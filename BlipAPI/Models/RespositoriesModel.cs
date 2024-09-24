using Newtonsoft.Json;

namespace BlipAPI.Models
{
    public class RespositoriesModel
    {
    public string FullName { get; set; }
    public string Description { get; set; }
    public string Image{ get; set; }
    }
  public class GitHubRepoResponse
  {
   
    public string FullName { get; set; }
  
    public string Description { get; set; }
  
    public string Language { get; set; }
  
    public DateTime CreatedAt { get; set; }
  
    public User User { get; set; }
  }

  public class User
  {
   
    public string Image { get; set; }
  }
}