using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Infrastructure.Repositories;

namespace AuthKit.Infrastructure.Persistance.DashboardAggregate.Repositories
{
    public class DashboardUserEfRepository : EfRepository<ApplicationDbContext, DashboardUser, Guid>, IDashboardUserRepository
    {
        public DashboardUserEfRepository(ApplicationDbContext dbContext) : base(dbContext, true)
        {

        }
    }
}
