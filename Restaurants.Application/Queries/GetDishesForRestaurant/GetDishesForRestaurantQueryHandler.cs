using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Extensions;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Queries.GetDishesForRestaurant
{
    public class GetDishesForRestaurantQueryHandler : IRequestHandler<GetDishesForRestaurantQuery, IEnumerable<DishDto>>
    {
        private readonly ILogger<GetDishesForRestaurantQueryHandler> _logger;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public GetDishesForRestaurantQueryHandler(ILogger<GetDishesForRestaurantQueryHandler> logger,
            IRestaurantRepository restaurantRepository,
            IMapper mapper)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DishDto>> Handle(GetDishesForRestaurantQuery request, CancellationToken cancellationToken)
        {
           _logger.LogInformation("Retrieving dishes for restaurant with id: {RestaurantId}", request.RestaurantId);
            var restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var results = _mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);
            return results;
        }
    }
}
