using AuthKit.Application.DashboardAggregate.Commands;
using AuthKit.Application.Validations;

namespace AuthKit.Application.DashboardAggregate.Validations
{
    public interface ILoginDashboardUserCommandValidator : IValidator<LoginDashboardUserCommand>
    {
    }
}
