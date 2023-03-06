using System.ComponentModel.DataAnnotations;

namespace dotnetwebapi.configuration.configurations;

public class RedisCacheConfiguration
{
    public const string SECTION_NAME = "RedisCacheConfigurationSection";

    public required string ConnectionString { get; init; }
    public required string InstanceName { get; init; }
    public required TimeSpan TimeToLive { get; init; }
}
