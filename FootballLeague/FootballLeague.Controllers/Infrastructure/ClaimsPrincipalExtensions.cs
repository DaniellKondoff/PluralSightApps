using System.Security.Claims;

namespace FootballLeague.Controllers.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claimPrinciple)
        {
            return claimPrinciple.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdministrator(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.IsInRole(ControllerConstants.AdministratorRole);
        }
    }
}
