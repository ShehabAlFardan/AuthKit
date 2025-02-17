using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.OrganizationAggregate
{
    public interface IOrganizationRepository : IRepository<Organization, Guid>
    {
    }
}
