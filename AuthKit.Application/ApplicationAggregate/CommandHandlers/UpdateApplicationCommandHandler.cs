using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.ApplicationAggregate.Dtos;
using AuthKit.Application.ApplicationAggregate.Queries;
using AuthKit.Application.ApplicationAggregate.Validations;
using AuthKit.Application.DashboardAggregate.Queries;
using AuthKit.Application.Exceptions;
using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Domain.DashbaordAggregate;
using MediatR;

namespace AuthKit.Application.ApplicationAggregate.CommandHandlers
{
    public class UpdateApplicationCommandHandler : IRequestHandler<UpdateApplicationCommand, UpdateApplicationResponse>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IUpdateApplicationCommandValidator _commandValidator;
        private readonly IApplicationQueries _applicationQueries;
        public UpdateApplicationCommandHandler(IApplicationRepository applicationRepository,
            IUpdateApplicationCommandValidator commandValidator,
            IDashboardUserRepository dashboardUserRepository,
            IApplicationQueries applicationQueries)
        {
            _applicationRepository = applicationRepository;
            _commandValidator = commandValidator;
            _applicationQueries = applicationQueries;
        }

        public async Task<UpdateApplicationResponse> Handle(UpdateApplicationCommand command, CancellationToken cancellationToken)
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

            application.UpdateApplication(command.Name, command.ApplicationType);

            await _applicationRepository.UpdateAsync(application);

            var response = new UpdateApplicationResponse
            {
                Id = application.Id,
                Name = application.Name,
                ApplicationType = application.ApplicationType
            };

            return response;

        }
    }
}
