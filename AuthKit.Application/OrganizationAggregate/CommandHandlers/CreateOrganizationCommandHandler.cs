using AuthKit.Application.Exceptions;
using AuthKit.Application.OrganizationAggregate.Commands;
using AuthKit.Application.OrganizationAggregate.Dtos;
using AuthKit.Application.OrganizationAggregate.Validations;
using MediatR;

namespace AuthKit.Application.OrganizationAggregate.CommandHandlers
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, CreateOrganizationResponse>
    {
        private readonly ICreateOrganizationCommandValidator _commandValidator;

        public CreateOrganizationCommandHandler(ICreateOrganizationCommandValidator commandValidator)
        {
            _commandValidator = commandValidator;
        }

        public async Task<CreateOrganizationResponse> Handle(CreateOrganizationCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return new CreateOrganizationResponse
            {
                Id = new Guid(),
                Name = command.Name,
                ApplicationId = command.ApplicationId,
            };

        }
    }
}
