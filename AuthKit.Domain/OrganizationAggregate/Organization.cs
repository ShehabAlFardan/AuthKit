namespace AuthKit.Domain.OrganizationAggregate
{
    public class Organization
    {
        private Guid _id;
        private Guid _applicationId;
        private string _name;
        private Guid _createdBy;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public Guid Id => _id;
        public Guid ApplicationId => _applicationId;
        public string Name => _name;
        public Guid CreatedBy => _createdBy;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt;

        protected Organization()
        {
            
        }

        public Organization(string name, Guid applicationId, Guid createdBy)
        {
            _id = Guid.NewGuid();
            _applicationId = applicationId;
            _name = name;
            _createdBy = createdBy;
            _createdAt = DateTime.Now;
            _updatedAt = null;
        }
    }
}
