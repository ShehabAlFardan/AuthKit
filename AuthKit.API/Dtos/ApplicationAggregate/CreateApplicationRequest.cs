using AuthKit.Domain.Kernal;

namespace AuthKit.API.Dtos.ApplicationAggregate
{
    public class CreateApplicationRequest
    {
        public string Name { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
    }
}
