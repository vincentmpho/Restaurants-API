using Restaurants.Domain.Models;

namespace Restaurants.Application.DTOs
{
    public class RestaurantDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; } 
        public List<DishDto> Dishes { get; set; } = []; 


        public static RestaurantDto? FromEntity(Restaurant? restaurant)
        {

            if (restaurant == null) return null;

            return new RestaurantDto()

            {
                Category = restaurant.Category,
                Description = restaurant.Description,
                Id = restaurant.Id,
                HasDelivery = restaurant.HasDelivery,
                Name = restaurant.Name,
                City = restaurant.Address.City,
                Street = restaurant.Address.Street,
                PostalCode = restaurant.Address.PostalCode,
                Dishes= restaurant.Dishes.Select( DishDto.FromEntity).ToList()
            };
        }
    }
}
