using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Commands.DeleteRestaurant;
using Restaurants.Domain.Extensions;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, bool>
    {
        private readonly ILogger<UpdateRestaurantCommandHandler> _logger;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
            IRestaurantRepository restaurantRepository, IMapper mapper)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Updating restaurant with id : {request.Id}");
            var restaurant = await _restaurantRepository.GetByIdAsync(request.Id);

            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
            restaurant.Name = request.Name;
            restaurant.Description = request.Description;
            restaurant.HasDelivery = request.HasDelivery;

          await _restaurantRepository.SaveChanges();

            return true;
        }
    }
}
