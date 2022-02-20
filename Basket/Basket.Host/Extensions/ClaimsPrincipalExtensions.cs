using System.Security.Claims;

namespace Basket.Host.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(x => x.Type == "sub")?.Value
                ?? throw new InvalidOperationException("Principal has not sub claim");
        }
    }
}
