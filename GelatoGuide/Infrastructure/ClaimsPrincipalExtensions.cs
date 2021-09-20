using System.Security.Claims;
using static GelatoGuide.WebConstants;

namespace GelatoGuide.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(Roles.AdminName);
        public static bool IsPremium(this ClaimsPrincipal user)
            => user.IsInRole(Roles.PremiumName);
    }
}
