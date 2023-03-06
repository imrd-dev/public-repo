using System.ComponentModel.DataAnnotations;

namespace dotnetwebapi.configuration.configurations;

public class RedisCacheConfiguration
{
    public const string SECTION_NAME = "RedisCacheConfigurationSection";

    [Required(ErrorMessage = "Redis cache connection string configuration value is required")]
    public required string ConnectionString { get; init; }

    [Required(ErrorMessage = "Redis cache instance name configuration value is required")]
    public required string InstanceName { get; init; }

    [Range(type: typeof(TimeSpan), "01:00:00", "05:00:00", 
        ErrorMessage = "Redis cache time to live configuration value must be between 1 and 5 hours")]
    public required TimeSpan TimeToLive { get; init; }
}
