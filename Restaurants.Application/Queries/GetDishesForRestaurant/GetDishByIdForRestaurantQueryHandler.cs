﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Extensions;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Queries.GetDishesForRestaurant
{
    public class GetDishByIdForRestaurantQueryHandler : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
    {
        private readonly ILogger<GetDishByIdForRestaurantQueryHandler> _logger;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public GetDishByIdForRestaurantQueryHandler(ILogger<GetDishByIdForRestaurantQueryHandler> logger,
            IRestaurantRepository restaurantRepository,
            IMapper mapper)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
            _mapper = mapper;
        }
        public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Retrieving dish: {DishId}, for restaurant with id: {RestaurantId}",
                  request.DishId,
                  request.RestaurantId);

            var restaurant = await _restaurantRepository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null) throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);

            if (dish == null) throw new NotFoundException(nameof(Dish), request.DishId.ToString());
            
            var result= _mapper.Map<DishDto>(dish);
            return result;
        }
    }
}
