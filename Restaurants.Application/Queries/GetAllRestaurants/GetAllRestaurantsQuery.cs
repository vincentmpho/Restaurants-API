using MediatR;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Queries
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
    {
        public string SerchPhrase { get; set; }
    }
}
