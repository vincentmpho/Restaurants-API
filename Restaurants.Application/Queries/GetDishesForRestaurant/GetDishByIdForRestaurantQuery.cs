using MediatR;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Queries.GetDishesForRestaurant
{
    public class GetDishByIdForRestaurantQuery : IRequest<DishDto>
    {
        public GetDishByIdForRestaurantQuery(Guid restaurantId, int dishId)
        {
            RestaurantId = restaurantId;
            DishId = dishId;
        }

        public Guid RestaurantId { get; }
        public int DishId { get; }
    }
}
