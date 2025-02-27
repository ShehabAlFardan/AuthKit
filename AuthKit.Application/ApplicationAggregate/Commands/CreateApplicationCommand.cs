using AuthKit.Application.ApplicationAggregate.Dtos;
using AuthKit.Domain.Kernal;
using MediatR;

namespace AuthKit.Application.ApplicationAggregate.Commands
{
    public class CreateApplicationCommand : IRequest<CreateApplicationResponse>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
    }
}
