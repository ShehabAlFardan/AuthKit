using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Application.DashboardAggregate.Validations;
using AuthKit.Application.Validations;
using FluentValidation;

namespace AuthKit.Infrastructure.Validation.Fluent.DashboardAggregate
{
    public class CreateDashboardUserCommandFluentValidator : AbstractValidator<CreateDashboardUserCommand>, ICreateDashboardUserCommandValidator
    {
        public CreateDashboardUserCommandFluentValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Name is required.")
           .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                        .NotEmpty().WithMessage("Password is required.")
                        .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                        .Matches(@"[!@#$%^&*(),.?""':{}|<>]").WithMessage("Password must contain at least one special character.");

        }
        public async Task<ValidationResult> ValidateAsync(CreateDashboardUserCommand entity)
        {
            var validationResult = await base.ValidateAsync(entity);
            return validationResult.ToAppValidationResult();
        }
    }
}
