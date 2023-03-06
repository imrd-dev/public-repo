using dotnetwebapi.configuration.configurations;
using dotnetwebapi.configuration.validators;
using Microsoft.Extensions.Options;

namespace dotnetwebapi.configuration.extensions;

public static class OptionsBuilderExtensions
{
    public static OptionsBuilder<RedisCacheConfiguration> ValidateFluentValidation(this OptionsBuilder<RedisCacheConfiguration> optionsBuilder)
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<RedisCacheConfiguration>, RedisCacheConfigurationOptionsValidator>();
        return optionsBuilder;
    }
}
