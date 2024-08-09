using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Application.Services.Interfaces;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Services
{
    public class RestaurantsService : IRestaurantsService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILogger<RestaurantsService> _logger;
        private readonly IMapper _mapper;

        public RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Guid> Create(CreateRestaurantDto dto)
        {
            _logger.LogInformation("Creating a new restaurant");

            var rstaurant = _mapper.Map<Restaurant>(dto);
            Guid id = await _restaurantRepository.Create(rstaurant);
                return id;
        }

        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            _logger.LogInformation("Getting all restaurants");
            var restaurants = await _restaurantRepository.GetAllAsync();

            var rstaurantsDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);


            return rstaurantsDtos!;
        }

        public async Task<RestaurantDto> GetById(Guid id)
        {
            _logger.LogInformation($"Getting Restaurants by ID {id}");
            var restaurant = await _restaurantRepository.GeyByIdAsync(id);
            var restaurantsDto = _mapper.Map<RestaurantDto?>(restaurant);

            return restaurantsDto;
        }
    }
}
