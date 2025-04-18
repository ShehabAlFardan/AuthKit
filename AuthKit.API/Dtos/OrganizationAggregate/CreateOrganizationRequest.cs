namespace AuthKit.API.Dtos.OrganizationAggregate
{
    public class CreateOrganizationRequest
    {
        public string Name { get; set; }
        public Guid ApplicationId { get; set; }
    }
}

