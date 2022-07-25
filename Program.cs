using babadinier.poc.httpClient;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("Github", client => 
{
     client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
     client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpRequestsSample");
});
builder.Services.AddTransient<IGitHubClient, GitHubClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
