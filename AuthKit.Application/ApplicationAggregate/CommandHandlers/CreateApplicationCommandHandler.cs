using System.Security.Cryptography;
using AuthKit.Application.ApplicationAggregate.Commands;
using AuthKit.Application.ApplicationAggregate.Dtos;
using AuthKit.Application.ApplicationAggregate.Validations;
using AuthKit.Application.DashboardAggregate.Queries;
using AuthKit.Application.Exceptions;
using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Domain.DashbaordAggregate;
using MediatR;


namespace AuthKit.Application.ApplicationAggregate.CommandHandlers
{
    public class CreateApplicationCommandHandler : IRequestHandler<CreateApplicationCommand, CreateApplicationResponse>
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ICreateApplicationCommandValidator _commandValidator;
        private readonly IDashboardUserQueries _dashboardUserQueries;
        public CreateApplicationCommandHandler(IApplicationRepository applicationRepository, 
            ICreateApplicationCommandValidator commandValidator, 
            IDashboardUserRepository dashboardUserRepository,
            IDashboardUserQueries dashboardUserQueries)
        {
            _applicationRepository = applicationRepository;
            _commandValidator = commandValidator;
            _dashboardUserQueries = dashboardUserQueries;
        }

        public async Task<CreateApplicationResponse> Handle(CreateApplicationCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var user = await _dashboardUserQueries.GetDashboardUserById(command.UserId);

            if (user == null)
            {
                throw new Exception($"User with ID {command.UserId} not found.");
            }

            var plainTextApiKey = GenerateApiKey();

            var application = user.CreateApplication(command.Name, command.ApplicationType, plainTextApiKey);

            await _applicationRepository.InsertAsync(application);

            var response = new CreateApplicationResponse
            {
                Id = application.Id,
                Name = application.Name,
                ApplicationType = application.ApplicationType,
                ApiKey = plainTextApiKey
            };

            return response;
        }

        private static string GenerateApiKey()
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[32];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes) + "-" + Guid.NewGuid().ToString("N");
        }
    }
}
