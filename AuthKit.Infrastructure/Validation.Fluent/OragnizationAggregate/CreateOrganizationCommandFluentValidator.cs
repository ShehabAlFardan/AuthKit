using AuthKit.Application.OrganizationAggregate.Commands;
using AuthKit.Application.OrganizationAggregate.Validations;
using AuthKit.Application.Validations;
using FluentValidation;

namespace AuthKit.Infrastructure.Validation.Fluent.OragnizationAggregate
{
    public class CreateOrganizationCommandFluentValidator : AbstractValidator<CreateOrganizationCommand>, ICreateOrganizationCommandValidator
    {
        public CreateOrganizationCommandFluentValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Organization name is required.")
            .MinimumLength(3).WithMessage("Organization name must be at least 3 characters long.")
            .MaximumLength(30).WithMessage("Organization name cannot exceed 30 characters.");

            RuleFor(x => x.ApplicationId)
                .NotEmpty().WithMessage("ApplicationId is required.");
        }
        public async Task<ValidationResult> ValidateAsync(CreateOrganizationCommand entity)
        {
            var validationResult = await base.ValidateAsync(entity);
            return validationResult.ToAppValidationResult();
        }
    }
}
