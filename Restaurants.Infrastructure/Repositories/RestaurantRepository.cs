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

        public async Task<Guid> Create(Restaurant entity)
        {
            _dbContext.Restaurants.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(Restaurant entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync()
        {
            var restaurants = await _dbContext.Restaurants.ToListAsync();
            return restaurants;
        }

        public async Task<(IEnumerable<Restaurant>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber)
        {
            var searchPhraseLower = searchPhrase?.ToLower();

            var baseQuery = _dbContext
                .Restaurants
                .Where(r => searchPhraseLower == null || (r.Name.ToLower().Contains(searchPhraseLower)
                                             || r.Description.ToLower().Contains(searchPhraseLower)));

            var totalCount = await baseQuery.CountAsync();


            var restaurants = await baseQuery
                .Skip(pageSize * (pageNumber-1))
                .Take(pageSize)
                .ToListAsync();

            return (restaurants, totalCount);
        }

        public async Task<Restaurant> GetByIdAsync(Guid id)
        {
            var restaurants = await _dbContext.Restaurants
                .Include(r=> r.Dishes)
                .FirstOrDefaultAsync(x=> x.Id == id);

            return restaurants;
        }

        public async Task SaveChanges()
        {
             await _dbContext.SaveChangesAsync();
        }
    }
}
