using AuthKit.Application.DashboardAggregate.Dtos;
using MediatR;

namespace AuthKit.Application.DashboardAggregate.Commands
{
    public class LoginDashboardUserCommand : IRequest<LoginDashboardUserResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
