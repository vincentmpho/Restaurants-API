using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Interfaces.Repositories;

namespace Restaurants.Application.Commands.DeleteRestaurant
{
    internal class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, bool>
    {
        private readonly ILogger<DeleteRestaurantCommandHandler> _logger;
        private readonly IRestaurantRepository _restaurantRepository;

        public DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
            IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Deleting restaurant with id : {request.Id}");
            var restaurant = await _restaurantRepository.GeyByIdAsync(request.Id);

            if ( restaurant ==null )
            {
                return false;
            }
            await _restaurantRepository.Delete(restaurant);
            return true;
        }
    }
}
