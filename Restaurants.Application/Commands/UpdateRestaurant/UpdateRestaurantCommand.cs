using MediatR;

namespace Restaurants.Application.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand :IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
    }
}
