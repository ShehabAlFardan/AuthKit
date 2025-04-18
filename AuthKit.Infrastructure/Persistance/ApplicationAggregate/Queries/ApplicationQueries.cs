using AuthKit.Application.ApplicationAggregate.Queries;
using Microsoft.EntityFrameworkCore;

namespace AuthKit.Infrastructure.Persistance.ApplicationAggregate.Queries
{
    public class ApplicationQueries : IApplicationQueries
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ApplicationQueries(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Domain.ApplicationAggregate.Application> GetApplicationById(Guid ApplicationId, Guid UserId)
        {
            var application = await _applicationDbContext.Applications
                               .Where(app => app.Id == ApplicationId && app.DashboardUserId == UserId)
                               .FirstOrDefaultAsync();

            return application;
        }

        public async Task<List<Domain.ApplicationAggregate.Application>> GetApplicationsByDashboardUserId(Guid UserId)
        {
            return await _applicationDbContext.Applications
                    .Where(app => app.DashboardUserId == UserId)
                    .ToListAsync();
        }
    }
}
