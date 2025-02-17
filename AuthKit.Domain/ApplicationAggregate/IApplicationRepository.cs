using AuthKit.Domain.Repositories;

namespace AuthKit.Domain.ApplicationAggregate
{
    public interface IApplicationRepository : IRepository<Application, Guid>
    {
    }
}
