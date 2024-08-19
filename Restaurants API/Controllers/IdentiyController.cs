using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Commands.AssignUser;
using Restaurants.Application.Commands.UpdateUserDetails;
using Restaurants.Domain.Contants;

namespace Restaurants_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentiyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IdentiyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPatch("user")]
        public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        
        [HttpPost("userRole")]
        [Authorize(Roles =UserRoles.Admin)]
        public async Task<IActionResult> AssignUserRole(AssignUserCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
