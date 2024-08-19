using MediatR;

namespace Restaurants.Application.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommand :IRequest
    {
        public DateOnly? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
    }
}
