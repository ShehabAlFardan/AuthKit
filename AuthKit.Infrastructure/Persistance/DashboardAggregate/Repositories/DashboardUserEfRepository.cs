using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Infrastructure.Repositories;

namespace AuthKit.Infrastructure.Persistance.DashboardAggregate.Repositories
{
    class DashboardUserRepository : EfRepository<ApplicationDbContext, DashboardUser, Guid>, IDashboardUserRepository
    {
        public DashboardUserRepository(ApplicationDbContext dbContext) : base(dbContext, true)
        {

        }
    }
}
