using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Extensions;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Commands.AssignUser
{
    public class AssignUserCommandHandler : IRequestHandler<AssignUserCommand>
    {
        private readonly ILogger<AssignUserCommandHandler> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AssignUserCommandHandler(ILogger<AssignUserCommandHandler> logger,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task Handle(AssignUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Assigning user role: {@Request}", request);
            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserEmail);
            }

            var role = await _roleManager.FindByNameAsync(request.RoleName);
            if (role == null)
            {
                throw new NotFoundException(nameof(User), request.RoleName);
            }

          await _userManager.AddToRoleAsync(user, role.Name!);

        }
    }
}
