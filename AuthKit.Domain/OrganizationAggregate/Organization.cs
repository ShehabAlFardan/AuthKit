namespace AuthKit.Domain.OrganizationAggregate
{
    public class Organization
    {
        private Guid _id;
        private string _name;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public Guid Id => _id;
        public string Name => _name;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt;

        protected Organization()
        {
            
        }

        public Organization(string name)
        {
            _id = Guid.NewGuid();
            _name = name;
            _createdAt = DateTime.Now;
            _updatedAt = null;
        }
    }
}
