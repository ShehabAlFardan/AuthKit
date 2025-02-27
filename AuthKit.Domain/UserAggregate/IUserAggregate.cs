using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.UserAggregate
{
    public interface IUserAggregate : IRepository<User, Guid>
    {
    }
}
