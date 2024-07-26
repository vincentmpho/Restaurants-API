namespace Restaurants.Domain.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int KiloCaloriess { get; set; }
        public Guid RestaurantId { get; set; } 
    }
}
