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

    }
}
