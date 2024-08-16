using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Interfaces.Repositories;

namespace Restaurants.Application.Queries.GetAllRestaurants
{
    public class GetRestaurantByIdQueryHandler : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto?>
    {
        private readonly ILogger<GetRestaurantByIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;

        public GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger,
           IMapper mapper, IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<RestaurantDto?> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Getting Restaurants by ID {request.Id}");
            var restaurant = await _restaurantRepository.GetByIdAsync(request.Id);
            var restaurantsDto = _mapper.Map<RestaurantDto?>(restaurant);
            return restaurantsDto;
        }
    }
}
