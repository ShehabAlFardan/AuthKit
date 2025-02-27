using AuthKit.Application.Validations;

namespace AuthKit.Infrastructure.Validation.Fluent
{
    public static class FluentValidationExtension
    {
        public static ValidationResult ToAppValidationResult(
            this FluentValidation.Results.ValidationResult fluentValidationResult)
        {
            ValidationResult appValidationResult = new()
            {
                IsValid = fluentValidationResult.IsValid
            };

            if (fluentValidationResult.Errors != null)
            {
                appValidationResult.Errors = new List<ValidationError>();

                foreach (var validationError in fluentValidationResult.Errors)
                {
                    appValidationResult.Errors.Add(new ValidationError
                    {
                        Message = validationError.ErrorMessage,
                        Code = validationError.ErrorCode,
                        Path = validationError.PropertyName
                    });
                }
            }
            return appValidationResult;
        }
    }
}
