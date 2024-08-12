using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Commands.CreateRestaurant;
using Restaurants.Application.Queries;

namespace Restaurants_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var restaurants = await  _mediator.Send(new GetAllRestaurantsQuery());
            return StatusCode(StatusCodes.Status200OK, restaurants);
        }

        [HttpGet("{id}")]
        public async Task< IActionResult> GetById(Guid id)  
        {
            var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));
            if (restaurant == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return StatusCode(StatusCodes.Status200OK, restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            // Create the restaurant and get the ID
            Guid id = await _mediator.Send(command);

            // Optionally, retrieve the created restaurant to include it in the response
            var createdRestaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));

            // Return the created restaurant details along with the CreatedAtAction response
            return CreatedAtAction(
                nameof(GetById),
                new { id },
                createdRestaurant
            );
        }

    }
}
