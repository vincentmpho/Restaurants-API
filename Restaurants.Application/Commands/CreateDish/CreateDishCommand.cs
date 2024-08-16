using MediatR;

namespace Restaurants.Application.Commands.CreateDish
{
    public class CreateDishCommand :IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int KiloCaloriess { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
