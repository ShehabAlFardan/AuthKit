namespace AuthKit.Application.DashboardAggregate.Dtos
{
    public class LoginDashboardUserResponse
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public int ExpiresIn { get; set; }

    }
}
