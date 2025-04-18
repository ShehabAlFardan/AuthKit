using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.ApplicationAggregate.Queries;
using AuthKit.Application.ApplicationAggregate.Validations;
using AuthKit.Application.Exceptions;
using AuthKit.Domain.ApplicationAggregate;
using MediatR;

namespace AuthKit.Application.ApplicationAggregate.CommandHandlers
{
    public class DeleteApplicationCommandHandler : IRequestHandler<DeleteApplicationCommand, bool>
    {
        private readonly IDeleteApplicationCommandValidator _commandValidator;
        private readonly IApplicationQueries _applicationQueries;
        private readonly IApplicationRepository _applicationRepository;

        public DeleteApplicationCommandHandler(
            IDeleteApplicationCommandValidator commandValidator,
            IApplicationQueries applicationQueries,
             IApplicationRepository applicationRepository
            )
        {
            _commandValidator = commandValidator;
            _applicationQueries = applicationQueries;
            _applicationRepository = applicationRepository;

        }
        public async Task<bool> Handle(DeleteApplicationCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var application = await _applicationQueries.GetApplicationById(command.ApplicationId, command.DashboardUserId);

            if (application == null)
            {
                throw new Exception($"Application with ID {command.ApplicationId} not found.");
            }

            await _applicationRepository.DeleteAsync(application, cancellationToken);

            return true;
        }
    }
}
