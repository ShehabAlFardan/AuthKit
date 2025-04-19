using AuthKit.Domain.Kernal;

namespace AuthKit.Application.ApplicationAggregate.Dtos
{
    public class CreateApplicationResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ApplicationTypeEnum ApplicationType { get; set; }
        public string ApiKey { get; set; }
    }
}
