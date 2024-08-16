using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Commands.CreateDish
{
    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, int>
    {
        private readonly ILogger<CreateDishCommandHandler> _logger;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IDishesRepository _dishesRepository;
        private readonly IMapper _mapper;

        public CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
            IRestaurantRepository restaurantRepository,
            IDishesRepository dishesRepository,
            IMapper mapper)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
            _dishesRepository = dishesRepository;
            _mapper = mapper;
        }


        public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Create new dish:{@DishRequest}", request);
            var restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant is null)
            {
                _logger.LogError("Restaurant with ID {RestaurantId} not found.", request.RestaurantId);
                throw new ArgumentException($"Restaurant with ID {request.RestaurantId} does not exist.");
            }


            var dish = _mapper.Map<Dish>(request);

           return  await _dishesRepository.create(dish);

            
                
     
        }
    }
}
