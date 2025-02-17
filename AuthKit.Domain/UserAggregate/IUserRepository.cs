using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.UserAggregate
{
    public interface IUserRepository : IRepository<User, Guid>
    {
    }
}
