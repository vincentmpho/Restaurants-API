using MediatR;
using Restaurants.Application.DTOs;
using Restaurants.Application.Queries;

namespace Restaurants.Application.Queries
{
    public class GetDishesForRestaurantQuery : IRequest<IEnumerable<DishDto>>
    {
       
        // Constructor to initialize the RestaurantId
        public GetDishesForRestaurantQuery(Guid restaurantId)
        {
            RestaurantId = restaurantId;
        }
        public Guid RestaurantId { get; }
    }
    
}

