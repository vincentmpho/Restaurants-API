using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Commands.CreateRestaurant;
using Restaurants.Application.Commands.DeleteRestaurant;
using Restaurants.Application.Commands.UpdateRestaurant;
using Restaurants.Application.Queries;
using Restaurants.Application.Queries.GetAllRestaurants;
using Restaurants.Domain.Contants;
using Serilog;

namespace Restaurants_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous ]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                Log.Information("Entering GetAll method.");

                var restaurants = await _mediator.Send(new GetAllRestaurantsQuery());

                Log.Information("Successfully retrieved all restaurants. Count: {Count}", restaurants.Count());

                return StatusCode(StatusCodes.Status200OK, restaurants);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting all restaurants.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                Log.Information("Entering GetById method with ID {Id}.", id);

                var restaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));

                if (restaurant == null)
                {
                    Log.Warning("Restaurant with ID {Id} not found.", id);
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                Log.Information("Successfully retrieved restaurant with ID {Id}.", id);
                return StatusCode(StatusCodes.Status200OK, restaurant);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while getting restaurant with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        [Authorize(Roles =UserRoles.Owner)]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
        {
            try
            {
                Log.Information("Entering CreateRestaurant method with command: {@Command}.", command);

                Guid id = await _mediator.Send(command);

                var createdRestaurant = await _mediator.Send(new GetRestaurantByIdQuery(id));

                Log.Information("Successfully created restaurant with ID {Id}.", id);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id },
                    createdRestaurant
                );
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while creating a restaurant.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant([FromRoute] Guid id, UpdateRestaurantCommand command)
        {
            try
            {
                Log.Information("Entering UpdateRestaurant method with ID {Id} and command: {@Command}.", id, command);

                command.Id = id;
                var isUpdated = await _mediator.Send(command);

                if (isUpdated)
                {
                    Log.Information("Successfully updated restaurant with ID {Id}.", id);
                    return StatusCode(StatusCodes.Status204NoContent, id);
                }

                Log.Warning("Restaurant with ID {Id} not found for update.", id);
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while updating restaurant with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant([FromRoute] Guid id)
        {
            try
            {
                Log.Information("Entering DeleteRestaurant method with ID {Id}.", id);

                var isDeleted = await _mediator.Send(new DeleteRestaurantCommand(id));

                if (isDeleted)
                {
                    Log.Information("Successfully deleted restaurant with ID {Id}.", id);
                    return StatusCode(StatusCodes.Status204NoContent, id);
                }

                Log.Warning("Restaurant with ID {Id} not found for deletion.", id);
                return StatusCode(StatusCodes.Status404NotFound, id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while deleting restaurant with ID {Id}.", id);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}