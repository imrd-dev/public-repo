using dotnetwebapi.configuration.configurations;
using dotnetwebapi.configuration.extensions;
using dotnetwebapi.configuration.validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services
    .AddOptions<RedisCacheConfiguration>()
    .Bind(configuration.GetRequiredSection(RedisCacheConfiguration.SECTION_NAME))
    .ValidateFluentValidation()
    .ValidateOnStart();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Singleton);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("configuration", ([FromServices] IOptions<RedisCacheConfiguration> redisCacheOptions) =>
{
    return redisCacheOptions.Value;
});

app.Run();
