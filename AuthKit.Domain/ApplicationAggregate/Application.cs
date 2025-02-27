using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Domain.Kernal;

namespace AuthKit.Domain.ApplicationAggregate
{
    public class Application
    {
        private Guid _id;
        private Guid _dashboardUserId;
        private string _name;
        private ApplicationTypeEnum _applicationType;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public Guid Id => _id;
        public Guid DashboardUserId => _dashboardUserId;
        public string Name => _name;
        public ApplicationTypeEnum ApplicationType => _applicationType;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt; 

        protected Application()
        {
            
        }

        public Application(string name, ApplicationTypeEnum applicationType)
        {
            _id = Guid.NewGuid();
            _name = name;
            _applicationType = applicationType;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

    }
}
