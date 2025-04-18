using AuthKit.Application.DashboardAggregate.Queries;
using AuthKit.Domain.DashbaordAggregate;
using Microsoft.EntityFrameworkCore;

namespace AuthKit.Infrastructure.Persistance.DashboardAggregate.Queries
{
    public class DashboardUserQueries : IDashboardUserQueries
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public DashboardUserQueries(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<DashboardUser?> GetDashboardUserByEmail(string email)
        {
            var dashboardUser = await _applicationDbContext.DashboardUsers.Where(user => user.Email == email).FirstOrDefaultAsync();

            return dashboardUser;
        }

        public async Task<DashboardUser> GetDashboardUserById(Guid Id)
        {
            var dashboardUser = await _applicationDbContext.DashboardUsers
                    .Include(user => user.Applications)
                    .Where(user => user.Id == Id)
                    .FirstOrDefaultAsync();

            return dashboardUser;
        }
    }
}
