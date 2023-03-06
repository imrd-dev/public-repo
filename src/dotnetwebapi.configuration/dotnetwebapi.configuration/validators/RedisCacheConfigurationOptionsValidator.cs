using dotnetwebapi.configuration.configurations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;

namespace dotnetwebapi.configuration.validators;

public class RedisCacheConfigurationOptionsValidator : IValidateOptions<RedisCacheConfiguration>
{
    // The fluent validator service for RedisCacheConfiguration class
    private readonly IValidator<RedisCacheConfiguration> _fluentValidator;

    public RedisCacheConfigurationOptionsValidator(IValidator<RedisCacheConfiguration> fluentValidator)
    {
        this._fluentValidator = fluentValidator;
    }

    public ValidateOptionsResult Validate(string? name, RedisCacheConfiguration options)
    {
        ValidationResult validationResult = _fluentValidator.Validate(options);

        // if the validation passed, return success validation result
        if (validationResult.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        // if validation failed, return failure result with error messages
        return ValidateOptionsResult.Fail(validationResult.Errors.Select(failure => failure.ErrorMessage));
    }
}
