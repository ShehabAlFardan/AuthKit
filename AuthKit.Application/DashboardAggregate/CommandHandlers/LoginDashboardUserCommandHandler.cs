using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Application.DashboardAggregate.Dtos;
using AuthKit.Application.DashboardAggregate.Queries;
using AuthKit.Application.DashboardAggregate.Validations;
using AuthKit.Application.Exceptions;
using AuthKit.Application.Services;
using AuthKit.Domain.DashbaordAggregate.Exceptions;
using MediatR;

namespace AuthKit.Application.DashboardAggregate.CommandHandlers
{
    public class LoginDashboardUserCommandHandler : IRequestHandler<LoginDashboardUserCommand, LoginDashboardUserResponse>
    {
        private readonly ILoginDashboardUserCommandValidator _commandValidator;
        private readonly IDashboardUserQueries _dashboardUserQueries;
        private readonly ITokenService _tokenService;


        public LoginDashboardUserCommandHandler(ILoginDashboardUserCommandValidator commandValidator, IDashboardUserQueries dashboardUserQueries, ITokenService tokenService)
        {
            _commandValidator = commandValidator;
            _dashboardUserQueries = dashboardUserQueries;
            _tokenService = tokenService;
        }

        public async Task<LoginDashboardUserResponse> Handle(LoginDashboardUserCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _commandValidator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var normalizedEmail = command.Email.Trim().ToLower();

            var existingUser = await _dashboardUserQueries.GetDashboardUserByEmail(normalizedEmail);

            if (existingUser == null)
            {
                throw new InvalidEmailOrPasswordException();
            }

            bool isPasswordValid = existingUser.VerifyPassword(command.Password);

            if (!isPasswordValid)
            {
                throw new InvalidEmailOrPasswordException();
            }

            var token = await _tokenService.GenerateAccessToken(existingUser);
            var refreshToken = await _tokenService.GenerateRefreshToken(existingUser);

            var expiresIn = 86400;

            return new LoginDashboardUserResponse
            {
                Token = token,
                RefreshToken = refreshToken,
                ExpiresIn = expiresIn
            };
        }
    }
}
