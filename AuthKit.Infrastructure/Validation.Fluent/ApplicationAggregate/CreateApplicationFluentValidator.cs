using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.ApplicationAggregate.Validations;
using AuthKit.Application.Validations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthKit.Infrastructure.Validation.Fluent.ApplicationAggregate
{
    public class CreateApplicationFluentValidator : AbstractValidator<CreateApplicationCommand>, ICreateApplicationCommandValidator
    {
        public CreateApplicationFluentValidator()
        {
            RuleFor(x => x.UserId)
           .NotEmpty().WithMessage("UserId is required.")
           .NotEqual(Guid.Empty).WithMessage("UserId must be a valid GUID.");

            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name is required.")
             .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

            RuleFor(x => x.ApplicationType)
           .IsInEnum().WithMessage("Invalid application type.");
        }
        public async Task<ValidationResult> ValidateAsync(CreateApplicationCommand entity)
        {
            var validationResult = await base.ValidateAsync(entity);
            return validationResult.ToAppValidationResult();
        }
    }
}
