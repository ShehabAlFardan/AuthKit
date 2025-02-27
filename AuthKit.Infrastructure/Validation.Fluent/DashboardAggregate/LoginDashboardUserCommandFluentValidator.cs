using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Application.DashboardAggregate.Validations;
using AuthKit.Application.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Infrastructure.Validation.Fluent.DashboardAggregate
{
    public class LoginDashboardUserCommandFluentValidator : AbstractValidator<LoginDashboardUserCommand>, ILoginDashboardUserCommandValidator
    {
        public LoginDashboardUserCommandFluentValidator()
        {
            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        }
        public async Task<ValidationResult> ValidateAsync(LoginDashboardUserCommand entity)
        {
            var validationResult = await base.ValidateAsync(entity);
            return validationResult.ToAppValidationResult();
        }
    }
}
