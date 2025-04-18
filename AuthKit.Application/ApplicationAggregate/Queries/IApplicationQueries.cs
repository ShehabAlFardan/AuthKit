namespace AuthKit.Application.ApplicationAggregate.Queries
{
    public interface IApplicationQueries
    {
        public Task<AuthKit.Domain.ApplicationAggregate.Application?> GetApplicationById(Guid ApplicationId, Guid UserId);
        public Task<List<AuthKit.Domain.ApplicationAggregate.Application>> GetApplicationsByDashboardUserId(Guid UserId);

    }
}
