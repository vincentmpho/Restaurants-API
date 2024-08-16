using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Extensions;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Commands.DeleteDishes
{
    internal class DeleteDishesForRestaurantCommandHandler : IRequestHandler<DeleteDishesForRestaurantCommand>
    {
        private readonly ILogger<DeleteDishesForRestaurantCommandHandler> _logger;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDishesRepository _dishesRepository;

        public DeleteDishesForRestaurantCommandHandler(ILogger<DeleteDishesForRestaurantCommandHandler> logger,
            IRestaurantRepository restaurantRepository,
            IDishesRepository dishesRepository)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
            _dishesRepository = dishesRepository;
        }
        public async Task Handle(DeleteDishesForRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogWarning("Removing all dishes from restaurant: {RestaurantID}", request.RestaurantId);
            var restaurant  = await _restaurantRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

             await _dishesRepository.Delete(restaurant.Dishes);
        }
    }
}
