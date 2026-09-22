using DotNetEnv;
using IngestService.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    Env.Load();
}
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddInfrastructureServices(builder.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();


