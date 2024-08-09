using Restaurants.Domain.Models;

namespace Restaurants.Domain.Interfaces.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable< Restaurant>> GetAllAsync();
        Task<Restaurant> GeyByIdAsync(Guid id);
        Task<Guid> Create(Restaurant entity);
    }
}
