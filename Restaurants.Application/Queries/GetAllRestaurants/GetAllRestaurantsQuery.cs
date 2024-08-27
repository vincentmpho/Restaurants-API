using MediatR;
using Restaurants.Application.Common;
using Restaurants.Application.DTOs;

namespace Restaurants.Application.Queries
{
    public class GetAllRestaurantsQuery : IRequest<PagedResult<RestaurantDto>>
    {
        public string? SerchPhrase { get; set; }
        public int pageNumber { get; set; }
        public int pageSize{ get; set; }
    }
}
