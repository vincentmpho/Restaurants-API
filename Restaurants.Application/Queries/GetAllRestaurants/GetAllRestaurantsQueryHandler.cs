using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Common;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Interfaces.Repositories;

namespace Restaurants.Application.Queries
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDto>>
    {
        private readonly ILogger<GetAllRestaurantsQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IRestaurantRepository _restaurantRepository;

        public GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger,
            IMapper mapper, IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _restaurantRepository = restaurantRepository;
        }
        public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all restaurants");
            var (restaurants, totalCount) = await _restaurantRepository.GetAllMatchingAsync(request.SerchPhrase,
                request.pageSize,
                request.pageNumber);

            var rstaurantsDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            var result = new PagedResult<RestaurantDto>(rstaurantsDtos, totalCount, request.pageSize, request.pageNumber);
            return result!;
        }
    }
}
