using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.OrganizationAggregate
{
    interface IOrganizationRepository : IRepository<Organization, Guid>
    {
    }
}
