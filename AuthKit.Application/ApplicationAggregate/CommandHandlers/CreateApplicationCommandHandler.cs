using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.ApplicationAggregate.Dtos;
using AuthKit.Application.ApplicationAggregate.Validations;
using AuthKit.Application.DashboardAggregate.Queries;
using AuthKit.Application.Exceptions;
using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Domain.Kernal;
using MediatR;
using applicationAggregate = AuthKit.Domain.ApplicationAggregate;


namespace AuthKit.Application.ApplicationAggregate.CommandHandlers
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, CreateApplicationResponse>
    {
        private readonly IApplicationRepository _applicationUserRepository;
        private readonly ICreateApplicationCommandValidator _commandValidator;
        private readonly IDashboardUserRepository _dashboardUserRepository;

        public CreateApplicationCommandHandler(IApplicationRepository applicationUserRepository, ICreateApplicationCommandValidator commandValidator, IDashboardUserRepository dashboardUserRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _commandValidator = commandValidator;
            _dashboardUserRepository = dashboardUserRepository;
        }

        public async Task<CreateApplicationResponse> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _dashboardUserRepository.GetByIdAsync(command.UserId);

            if (user == null)
            {
                throw new Exception($"User with ID {command.UserId} not found.");
            }

            var application = user.CreateApplication(command.Name, command.ApplicationType);

            await _dashboardUserRepository.UpdateAsync(user);

            var response = new CreateApplicationResponse
            {
                Id = new Guid(),
                Name = "rrr",
                ApplicationType = ApplicationTypeEnum.Individual
            };

            return response;
        }
    }
}
