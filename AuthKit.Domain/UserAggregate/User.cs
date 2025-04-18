namespace AuthKit.Domain.UserAggregate
{
    public class User
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private Guid _applicationId;
        private Guid? _organizationId;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public Guid Id => _id;
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string Email => _email;
        public string Password => _password;
        public Guid ApplicationId => _applicationId;
        public Guid? OrganizationId => _organizationId;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt;

        protected User()
        {
            
        }

        public User(string firstName, string lastName, string email, string password, Guid applicationId , Guid? organizationId)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _applicationId = applicationId;
            _organizationId = organizationId;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

    }
}
