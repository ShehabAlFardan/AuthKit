using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.ApplicationAggregate.Validations;
using AuthKit.Application.Validations;
using FluentValidation;

namespace AuthKit.Infrastructure.Validation.Fluent.ApplicationAggregate
{
    public class UpdateApplicationFluentValidator : AbstractValidator<UpdateApplicationCommand>, IUpdateApplicationCommandValidator
    {
        public UpdateApplicationFluentValidator()
        {
            RuleFor(x => x.DashboardUserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotEqual(Guid.Empty).WithMessage("UserId must be a valid GUID.");
            
            RuleFor(x => x.ApplicationId)
            .NotEmpty().WithMessage("ApplicationId is required.")
            .NotEqual(Guid.Empty).WithMessage("ApplicationId must be a valid GUID.");

            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is required.")
             .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.ApplicationType)
           .IsInEnum().WithMessage("Invalid application type.");
        }
        public async Task<ValidationResult> ValidateAsync(UpdateApplicationCommand entity)
        {
            var validationResult = await base.ValidateAsync(entity);
            return validationResult.ToAppValidationResult();
        }
    }
}
