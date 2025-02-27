using AuthKit.Domain.ApplicationAggregate;
using AuthKit.Domain.Kernal;

namespace AuthKit.Domain.DashbaordAggregate
{
    public class DashboardUser
    {
        private Guid _id;
        private string _name;
        private string _email;
        private string _password;
        private  List<Application> _applications;
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
            _password = HashPassword(password);
            _applications = new List<Application>();
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, _password);
        }

        public void update(string name)
        {
            _name = name;
            _updatedAt = DateTime.UtcNow;         
        }

        public Application CreateApplication(string applicatioName, ApplicationTypeEnum applicationType)
        {
            var newApplication = new Application(applicatioName, applicationType);

            if (_applications == null)
            {
                _applications = new List<Application>();
            }

            _applications.Add(newApplication);

            _updatedAt = DateTime.UtcNow;

            return newApplication;
        }
    }
}
