using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
public class AuthBaseController : ControllerBase
{
    protected Guid UserId => new(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new InvalidOperationException("UserId is missing"));
    protected string UserEmail => User.FindFirst(ClaimTypes.Email)?.Value;
}
