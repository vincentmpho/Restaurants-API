using Restaurants.Application.DTOs;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Services.Interfaces
{
    public interface IRestaurantsService

    {/// <summary>
     /// Retrieves a list of all restaurants.
     /// </summary>
     /// <returns>returns IEnumerable of Restaurant objects representing all restaurants.</returns>
     Task<IEnumerable<RestaurantDto>> GetAllRestaurants();

        /// <summary>
        /// Retrieves a restaurant by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the restaurant.</param>
        /// <returns>Returns a Restaurant object representing the restaurant with the specified ID.</returns>
        Task<RestaurantDto> GetById(Guid id);

        Task<Guid> Create(CreateRestaurantDto dto);
    }
}