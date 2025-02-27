using AuthKit.Domain.DashbaordAggregate;
using System.Security.Claims;

namespace AuthKit.Application.Services
{
    public interface ITokenService
    {
        Task<string> GenerateAccessToken(DashboardUser user);
        Task<string> GenerateRefreshToken(DashboardUser user);
        Task<ClaimsPrincipal> ValidateAccessToken(string token);
        Task<ClaimsPrincipal> ValidateRefreshToken(string token);
    }
}
