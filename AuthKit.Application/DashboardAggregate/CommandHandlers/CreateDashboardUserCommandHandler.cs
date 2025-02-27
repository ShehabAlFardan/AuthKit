using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Application.DashboardAggregate.Dtos;
using AuthKit.Application.DashboardAggregate.Queries;
using AuthKit.Application.DashboardAggregate.Validations;
using AuthKit.Application.Exceptions;
using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Domain.DashbaordAggregate.Exceptions;
using MediatR;

namespace AuthKit.Application.DashboardAggregate.CommandHandlers
{
    public class CreateDashboardUserCommandHandler : IRequestHandler<CreateDashboardUserCommand, CreateDashboardUserResponse>
    {
        private readonly ICreateDashboardUserCommandValidator _commandValidator;
        private readonly IDashboardUserRepository _dashboardUserRepository;
        private readonly IDashboardUserQueries _dashboardUserQueries;
        public CreateDashboardUserCommandHandler(ICreateDashboardUserCommandValidator commandValidator, 
            IDashboardUserRepository dashboardUserRepository,
            IDashboardUserQueries dashboardUserQueries)
        {
            _commandValidator = commandValidator;
            _dashboardUserRepository = dashboardUserRepository;
            _dashboardUserQueries = dashboardUserQueries;
        }
        public async Task<CreateDashboardUserResponse> Handle(CreateDashboardUserCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var normalizedEmail = command.Email.Trim().ToLower();

            if (await IsEmailAlreadyInUse(normalizedEmail))
            {
                throw new EmailAlreadyInUseException();
            }

            var dashboardUser = new DashboardUser(command.Name, normalizedEmail, command.Password);

            await _dashboardUserRepository.InsertAsync(dashboardUser);

            var response = new CreateDashboardUserResponse
            {
                Id = dashboardUser.Id,
                Name = dashboardUser.Name,
                Email = dashboardUser.Email 
            };

            return response;
        }

        private async Task<bool> IsEmailAlreadyInUse(string email)
        {
            var existingUser = await _dashboardUserQueries.GetDashboardUserByEmail(email);

            return existingUser != null;
        }

    }
}
