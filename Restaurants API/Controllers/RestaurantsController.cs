using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.DTOs;
using Restaurants.Application.Services;
using Restaurants.Application.Services.Interfaces;

namespace Restaurants_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantsService _restaurantsService;

        public RestaurantsController(IRestaurantsService restaurantsService)
        {
            _restaurantsService = restaurantsService;
        }

        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var restaurants = await  _restaurantsService.GetAllRestaurants();
            return StatusCode(StatusCodes.Status200OK, restaurants);
        }

        [HttpGet("{id}")]
        public async Task< IActionResult> GetById(Guid id)  
        {
            var restaurant = await _restaurantsService.GetById(id);
            if (restaurant == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
        {
            // Create the restaurant and get the ID
            Guid id = await _restaurantsService.Create(createRestaurantDto);

            // Optionally, retrieve the created restaurant to include it in the response
            var createdRestaurant = await _restaurantsService.GetById(id);

            // Return the created restaurant details along with the CreatedAtAction response
            return CreatedAtAction(
                nameof(GetById),
                new { id },
                createdRestaurant
            );
        }

    }
}
