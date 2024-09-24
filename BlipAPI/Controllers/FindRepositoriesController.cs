using BlipAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlipAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FindRepositoriesController : ControllerBase
  {
    private readonly IGitHubService _gitHubService;

    public FindRepositoriesController(IGitHubService gitHubService)
    {
      _gitHubService = gitHubService;
    }

    [HttpGet("cs-repositories")]
    public async Task<IActionResult> GetCSharpRepositories()
    {
      try
      {
        var repositories = await _gitHubService.GetCSharpRepositoriesAsync();
        if (repositories == null || !repositories.Any())
          return NotFound("Nenhum repositório encontrado.");

        return Ok(repositories);
      }
      catch (HttpRequestException httpEx)
      {
        Console.WriteLine($"Erro ao fazer a chamada HTTP: {httpEx.Message}");
        return StatusCode(500, $"Erro ao acessar o serviço externo: {httpEx.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erro: {ex.Message}");
        return StatusCode(500, $"Erro interno: {ex.Message}");
      }
    }
  }
}
