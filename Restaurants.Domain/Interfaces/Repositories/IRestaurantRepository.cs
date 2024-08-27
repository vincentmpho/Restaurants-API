using Restaurants.Domain.Models;

namespace Restaurants.Domain.Interfaces.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable< Restaurant>> GetAllAsync();
        Task<Restaurant> GetByIdAsync(Guid id);
        Task<Guid> Create(Restaurant entity);
        Task Delete(Restaurant entity);
        Task SaveChanges();
        Task<IEnumerable<Restaurant>> GetAllMatchingAsync(string? searchPhrase);
    }
}
