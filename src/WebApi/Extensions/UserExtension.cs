using System.Security.Claims;

namespace WebApi.Extensions
{
    public static class UserExtension
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
