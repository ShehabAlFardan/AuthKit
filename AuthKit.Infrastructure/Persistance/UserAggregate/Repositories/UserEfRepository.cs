using AuthKit.Domain.UserAggregate;
using AuthKit.Infrastructure.Repositories;


namespace AuthKit.Infrastructure.Persistance.UserAggregate.Repositories
{
    public class UserEfRepository : EfRepository<ApplicationDbContext, User, Guid>, IUserRepository
    {
        public UserEfRepository(ApplicationDbContext dbContext) : base(dbContext, true)
        {

        }
    }
}
