using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;
using Restaurants.Infrastructure.Peristence;

namespace Restaurants.Infrastructure.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantsDbContext _dbContext;

        public RestaurantRepository(RestaurantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await _dbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<Restaurant> GeyByIdAsync(Guid id)
        {
            var restaurants = await _dbContext.Restaurants.FirstOrDefaultAsync(x=> x.Id == id);
            return restaurants;
        }
    }
}
