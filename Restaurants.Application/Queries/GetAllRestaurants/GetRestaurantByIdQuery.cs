using MediatR;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Queries.GetAllRestaurants
{
    public class GetRestaurantByIdQuery : IRequest<RestaurantDto?>
    {
        public GetRestaurantByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
