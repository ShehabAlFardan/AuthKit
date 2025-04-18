using AuthKit.Application.ApplicationAggregate.Dtos;
using AuthKit.Domain.Kernal;
using MediatR;

namespace AuthKit.Application.ApplicationAggregate.Commands
{
    public class UpdateApplicationCommand : IRequest<UpdateApplicationResponse>
    {
        public Guid DashboardUserId { get; set; }
        public Guid ApplicationId { get; set; }
        public string Name{ get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
    }
}
