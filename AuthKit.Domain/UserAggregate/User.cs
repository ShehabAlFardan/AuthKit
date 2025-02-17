namespace AuthKit.Domain.UserAggregate
{
    public class User
    {
        private Guid _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public Guid Id => _id;
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public string Email => _email;
        public string Password => _password;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt;

        protected User()
        {
            
        }

        public User(string firstName, string lastName, string email, string password)
        {
            _id = Guid.NewGuid();
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;
        }

    }
}
