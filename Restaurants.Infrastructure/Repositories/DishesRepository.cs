using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Domain.Models;
using Restaurants.Infrastructure.Peristence;

namespace Restaurants.Infrastructure.Repositories
{
    public class DishesRepository : IDishesRepository
    {
        private readonly RestaurantsDbContext _dbContext;

        public DishesRepository(RestaurantsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> create(Dish entity)
        {
            _dbContext.Dishes.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete(IEnumerable<Dish> entities)
        {
            _dbContext.Dishes.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();

        }
    }
}
