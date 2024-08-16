using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Commands.CreateDish;
using Restaurants.Application.DTOs;
using Restaurants.Application.Queries;
using Restaurants.Application.Queries.GetDishesForRestaurant;

namespace Restaurants_API.Controllers
{
    [Route("api/restaurants/{restaurantId}/dishes")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DishesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute] Guid restaurantId, [FromBody] CreateDishCommand command)
        {
            // Set the RestaurantId in the command from the route parameter
            command.RestaurantId = restaurantId;

            await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateDish),
                new { restaurantId = restaurantId },
                command);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetAllForRestaurant([FromRoute] Guid restaurantId)
        {
           var dishes = await _mediator.Send(new GetDishesForRestaurantQuery(restaurantId));
            return StatusCode(StatusCodes.Status200OK, dishes);
        } 
        
        [HttpGet("{dishId}")]
        public async Task<ActionResult<IEnumerable<DishDto>>> GetByIdForRestaurant([FromRoute] Guid restaurantId,
            [FromRoute] int dishId)
        {
           var dish = await _mediator.Send(new GetDishByIdForRestaurantQuery(restaurantId, dishId));
            return StatusCode(StatusCodes.Status200OK, dish);
        }


    }
}
