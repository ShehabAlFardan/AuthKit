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
    public class DeleteApplicationFluentValidator : AbstractValidator<DeleteApplicationCommand>, IDeleteApplicationCommandValidator
    {
        public DeleteApplicationFluentValidator()
        {
            RuleFor(x => x.ApplicationId)
           .NotEmpty().WithMessage("ApplicationId is required.")
           .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid GUID format for ApplicationId.");

            RuleFor(x => x.DashboardUserId)
                .NotEmpty().WithMessage("DashboardUserId is required.")
                .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid GUID format for DashboardUserId.");
        }

        public async Task<ValidationResult> ValidateAsync(DeleteApplicationCommand entity)
        {
            var validationResult = await base.ValidateAsync(entity);
            return validationResult.ToAppValidationResult();
        }
    }
}
