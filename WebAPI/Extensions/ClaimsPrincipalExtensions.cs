using System.Security.Claims;

namespace WebAPI.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.Email);
    }

    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}