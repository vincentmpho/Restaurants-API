using Microsoft.AspNetCore.Mvc;
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
    }
}
