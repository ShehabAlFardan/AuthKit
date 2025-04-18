using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.Validations;

namespace AuthKit.Application.ApplicationAggregate.Validations
{
    public interface IDeleteApplicationCommandValidator : IValidator<DeleteApplicationCommand>
    {
    }
}
