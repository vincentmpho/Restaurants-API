using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Restaurants.Application.Users
{
    public class UserContext(IHttpContextAccessor htpContextAccessor) : IUserContext
    {
        public CurrentUser GetCurrentUser()
        {
            var user = htpContextAccessor?.HttpContext.User;
            if (user == null)
            {
                throw new InvalidOperationException("Users context is not present");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

            return new CurrentUser(userId, email, roles);
        }
    }
}
