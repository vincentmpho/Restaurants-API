using MediatR;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Commands.DeleteDishes
{
    public class DeleteDishesForRestaurantCommand :IRequest
    {
        public DeleteDishesForRestaurantCommand(Guid restaurantId)
        {
            RestaurantId = restaurantId;
        }
        public Guid RestaurantId { get; }
    }
}
