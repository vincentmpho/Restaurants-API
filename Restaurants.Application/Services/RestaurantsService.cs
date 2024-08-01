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

        public RestaurantsService(IRestaurantRepository restaurantRepository, ILogger<RestaurantsService> logger)
        {
            _restaurantRepository = restaurantRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
        {
            _logger.LogInformation("Getting all restaurants");
            var restaurants = await _restaurantRepository.GetAllAsync();

            var rstaurantsDto = restaurants.Select(r => new RestaurantDto() 
            { 
              Category = r.Category,
              Description = r.Description,
              Id = r.Id,
              HasDelivery = r.HasDelivery,
              Name = r.Name,
              City = r.Address.City,
              Street= r.Address.Street,
              PostalCode= r.Address.PostalCode,
            });
            return rstaurantsDto;
        }

        public async Task<RestaurantDto> GetById(Guid id)
        {
            _logger.LogInformation($"Getting Restaurants by ID {id}");
            var restaurants = await _restaurantRepository.GeyByIdAsync(id);
            return restaurants;
        }
    }
}
