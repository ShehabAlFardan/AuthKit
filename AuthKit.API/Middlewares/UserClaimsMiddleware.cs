using System.Security.Claims;

public class UserClaimsMiddleware
{
    private readonly RequestDelegate _next;

    public UserClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated ?? false)
        {
            var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                context.Items["UserId"] = userId;
            }

            if (!string.IsNullOrEmpty(email))
            {
                context.Items["UserEmail"] = email;
            }
        }

        await _next(context);
    }
}
