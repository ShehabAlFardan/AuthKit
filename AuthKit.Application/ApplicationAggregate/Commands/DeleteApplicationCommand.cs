using AuthKit.Application.ApplicationAggregate.Dtos;
using MediatR;

namespace AuthKit.Application.ApplicationAggregate.Commands
{
    public class DeleteApplicationCommand : IRequest<bool>
    {
        public Guid ApplicationId { get; set; }
        public Guid DashboardUserId { get; set; }

    }
}
