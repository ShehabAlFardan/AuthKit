using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Infrastructure.Repositories;

namespace AuthKit.Infrastructure.Persistance.ApplicationAggregate.Repositories
{
    public class ApplicationEfRepository : EfRepository<ApplicationDbContext, Domain.ApplicationAggregate.Application, Guid>, IApplicationRepository
    {
        public ApplicationEfRepository(ApplicationDbContext dbContext) : base(dbContext, true)
        {
            
        }
    }
}
