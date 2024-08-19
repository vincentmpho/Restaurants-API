using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Extensions;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Commands.UpdateUserDetails
{
    public class UpdateUserDetailsCommandHandler : IRequestHandler<UpdateUserDetailsCommand>
    {
        private readonly ILogger<UpdateUserDetailsCommandHandler> _logger;
        private readonly IUserContext _userContext;
        private readonly IUserStore<User> _userStore;

        public UpdateUserDetailsCommandHandler(ILogger<UpdateUserDetailsCommandHandler> logger,
            IUserContext userContext,
            IUserStore<User> userStore)
        {
            _logger = logger;
            _userContext = userContext;
            _userStore = userStore;
        }
        public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
        {
            var user = _userContext.GetCurrentUser();
            _logger.LogInformation("Updating user: {UserId} with {@Request}", user!.Id, request);

            var dbuser = await _userStore.FindByIdAsync(user!.Id, cancellationToken);

            if (dbuser == null)
            {
                throw new NotFoundException(nameof(user), user!.Id);
            }

            dbuser.Nationality = request.Nationality;
            dbuser.DateOfBirth = request.DateOfBirth;

           await _userStore.UpdateAsync(dbuser, cancellationToken);
        }
    }
}
