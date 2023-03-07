using dotnetwebapi.configuration.configurations;
using FluentValidation;

namespace dotnetwebapi.configuration.validators;

public class RedisCacheConfigurationValidator : AbstractValidator<RedisCacheConfiguration>
{
    public RedisCacheConfigurationValidator()
    {
        RuleFor(p => p.ConnectionString)
            .NotEmpty()
            .WithMessage("Redis cache connection string configuration value is required");

        RuleFor(p => p.InstanceName)
            .NotEmpty()
            .WithMessage("Redis cache instance name configuration value is required");

        RuleFor(p => p.TimeToLive)
            .InclusiveBetween(from: TimeSpan.FromHours(1), to: TimeSpan.FromHours(5))
            .WithMessage("Redis cache time to live configuration value must be between 1 and 5 hours");
    }
}
