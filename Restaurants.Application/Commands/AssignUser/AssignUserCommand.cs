using MediatR;

namespace Restaurants.Application.Commands.AssignUser
{
    public class AssignUserCommand :IRequest
    {
        public string UserEmail { get; set; }
        public string RoleName { get; set; }
    }
}
