using AuthKit.Application.OrganizationAggregate.Commands;
using AuthKit.Application.Validations;

namespace AuthKit.Application.OrganizationAggregate.Validations
{
    public interface ICreateOrganizationCommandValidator : IValidator<CreateOrganizationCommand>
    {
    }
}
