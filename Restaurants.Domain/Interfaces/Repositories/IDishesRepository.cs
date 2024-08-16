using Restaurants.Domain.Models;

namespace Restaurants.Domain.Interfaces.Repositories
{
    public interface IDishesRepository
    {
        Task<int> create(Dish entity);
    }
}
