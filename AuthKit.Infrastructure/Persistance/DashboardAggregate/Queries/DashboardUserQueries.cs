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
    }
}
