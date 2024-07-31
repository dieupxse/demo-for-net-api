using System.Security.Claims;

namespace DemoForNetAPI.Helpers;

public static class JwtHelper
{
    public static long GetUserId(this ClaimsIdentity? claimsIdentity)
    {
        if (claimsIdentity == null) return 0;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId)) userId = "0";
        return long.Parse(userId);
    }

    public static string GetEmailAddress(this ClaimsIdentity? claimsIdentity)
    {
        if (claimsIdentity == null) return string.Empty;
        return claimsIdentity.FindFirst(ClaimTypes.Email)?.Value ?? "";
    }
}