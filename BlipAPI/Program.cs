using BlipAPI.Infrastructure;
using BlipAPI.Interfaces;
using BlipTeste.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IGitHubRepositories, GitHubRepositories>();


builder.Services.AddScoped<IGitHubService, GitHubService>();

builder.Services.AddHttpClient<IGitHubService, GitHubService>(client =>
{
  client.BaseAddress = new Uri("https://api.github.com/");
  client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0"); 
  client.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github.v3+json");
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole(); 
builder.Logging.AddDebug();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();  

app.Run();
