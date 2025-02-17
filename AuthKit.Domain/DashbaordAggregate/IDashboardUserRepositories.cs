using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.DashbaordAggregate
{
    public interface IDashboardUserRepositories : IRepository<DashboardUser, Guid>
    {
    }
}
