using AuthKit.Domain.Kernal;

namespace AuthKit.API.Dtos.ApplicationAggregate
{
    public class UpdateApplicationRequest
    {
        public Guid ApplicationId { get; set; }
        public string Name { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
    }
}
