using AuthKit.Domain.ApplicationAggregate;

namespace AuthKit.Domain.DashbaordAggregate
{
    public class DashboardUser
    {
        private Guid _id;
        private string _name;
        private string _email;
        private string _password;
        private List<Application> _applications;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public Guid Id => _id;
        public string Name => _name;
        public string Email => _email;
        public string Password => _password;
        public IReadOnlyCollection<Application> Applications => _applications;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt;

        protected DashboardUser()
        {
            
        }

        public DashboardUser(string name, string email, string password)
        {
            _id = Guid.NewGuid();
            _name = name;
            _email = email;
            _password = password;
            _applications = new List<Application>();
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

    }
}
