using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Interfaces.Repositories;

namespace Restaurants.Application.Queries
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
    {
        private readonly ILogger<GetAllRestaurantsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;

        public GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
            IMapper mapper, IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all restaurants");
            var restaurants = await _restaurantRepository.GetAllAsync();
            var rstaurantsDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return rstaurantsDtos!;
        }
    }
}
