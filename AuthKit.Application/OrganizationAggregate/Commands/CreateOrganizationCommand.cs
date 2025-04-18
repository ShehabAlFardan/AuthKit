using AuthKit.Application.OrganizationAggregate.Dtos;
using MediatR;

namespace AuthKit.Application.OrganizationAggregate.Commands
{
    public class CreateOrganizationCommand : IRequest<CreateOrganizationResponse>
    {
        public string Name { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid UserId { get; set; }

    }
}
