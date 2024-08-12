using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Guid>
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILogger<CreateRestaurantCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository, ILogger<CreateRestaurantCommandHandler>logger,
           IMapper mapper )
        {
            _restaurantRepository = restaurantRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating a new restaurant");

            var rstaurant = _mapper.Map<Restaurant>(request);
            Guid id = await _restaurantRepository.Create(rstaurant);
            return id;
        }
    }
}
