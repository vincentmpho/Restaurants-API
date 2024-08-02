using Restaurants.Domain.Models;

namespace Restaurants.Application.DTOs
{
    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int KiloCaloriess { get; set; }
        
        public static DishDto FromEntity(Dish dish)
        {
            return new DishDto()
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                KiloCaloriess = dish.KiloCaloriess
            };
        }
    }
}
