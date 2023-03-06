using dotnetwebapi.configuration.configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services
    .AddOptions<RedisCacheConfiguration>()
    .Bind(configuration.GetRequiredSection(RedisCacheConfiguration.SECTION_NAME))
    .ValidateDataAnnotations();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("configuration", ([FromServices] IOptions<RedisCacheConfiguration> redisCacheOptions) =>
{
    return redisCacheOptions.Value;
});

app.Run();
