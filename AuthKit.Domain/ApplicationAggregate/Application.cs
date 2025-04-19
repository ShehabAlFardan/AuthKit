using System.Security.Cryptography;
using System.Text;
using AuthKit.Domain.DashbaordAggregate;
using AuthKit.Domain.Kernal;

namespace AuthKit.Domain.ApplicationAggregate
{
    public class Application
    {
        private Guid _id;
        private Guid _dashboardUserId;
        private string _name;
        private string _apiKey;
        private ApplicationTypeEnum _applicationType;
        private DateTime _createdAt;
        private DateTime? _updatedAt;

        public Guid Id => _id;
        public Guid DashboardUserId => _dashboardUserId;
        public string Name => _name;
        public string ApiKey => _apiKey;
        public ApplicationTypeEnum ApplicationType => _applicationType;
        public DateTime CreatedAt => _createdAt;
        public DateTime? UpdatedAt => _updatedAt; 

        protected Application()
        {
            
        }

        public Application(string name, ApplicationTypeEnum applicationType, Guid userDashboardId, string plainTextApiKey)
        {
            _id = Guid.NewGuid();
            _dashboardUserId = userDashboardId;
            _name = name;
            _applicationType = applicationType;
            _createdAt = DateTime.UtcNow;
            _updatedAt = null;

            _apiKey = HashApiKey(plainTextApiKey);
        }

        public void UpdateApplication(string name, ApplicationTypeEnum applicationType)
        {
            _name = name;
            _applicationType = applicationType;
            _updatedAt = DateTime.UtcNow;
        }

        private static string GenerateApiKey()
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes = new byte[32];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes) + "-" + Guid.NewGuid().ToString("N");
        }

        private static string HashApiKey(string apiKey)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(apiKey);
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public bool ValidateApiKey(string incomingApiKey)
        {
            var incomingHash = HashApiKey(incomingApiKey);
            return incomingHash == _apiKey;
        }

    }
}
