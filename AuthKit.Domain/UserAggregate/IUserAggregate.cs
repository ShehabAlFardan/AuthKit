using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.UserAggregate
{
    interface IUserAggregate : IRepository<User, Guid>
    {
    }
}
