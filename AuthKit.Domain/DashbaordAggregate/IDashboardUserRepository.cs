using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.DashbaordAggregate
{
    public interface IDashboardUserRepository : IRepository<DashboardUser, Guid>
    {
    }
}
