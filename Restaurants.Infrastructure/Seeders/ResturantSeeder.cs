using Microsoft.AspNetCore.Identity;
using Restaurants.Domain.Contants;
using Restaurants.Domain.Models;
using Restaurants.Infrastructure.Peristence;
using Restaurants.Infrastructure.Seeders.Interfaces;

namespace Restaurants.Infrastructure.Seeders
{
    public class ResturantSeeder(RestaurantsDbContext dbContext) : IResturantSeeder
    {
        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Restaurants.Any())
                {
                    var restautrants = GetRestaurants();
                    dbContext.Restaurants.AddRange(restautrants);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    dbContext.Roles.AddRange(roles);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles =
                [
                    new (UserRoles.User)
                    {
                        NormalizedName = UserRoles.User.ToUpper()
                    },
                    new (UserRoles.Owner)
                    {
                          NormalizedName= UserRoles.Owner.ToUpper()
                    },
                    new(UserRoles.Admin)
                    {
                        NormalizedName= UserRoles.Admin.ToUpper()
                    },
                ];
            return roles;
        }



        private IEnumerable<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurants = [

                new Restaurant
                {
            Name = "KFC",
            Category = "Fast Food",
            Description = 
            "KFC It's Finger Lickin' Good is an American fast food restaurant chain headquartered in Louisville, Kentucky.",
            ContactNumber ="0154738459",
            ContactEmail = "contact@kfc.com",
            HasDelivery = true,
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Streetwise Three with Regular Pap",
                    Description = "Three pieces of crispy KFC chicken served with a side of regular pap.",
                    Price = 59.90M
                },
                new Dish
                {
                    Name = "Bucket of Original Recipe Chicken",
                    Description = "A bucket of KFC's famous Original Recipe chicken, with 11 herbs and spices.",
                    Price = 145.00M
                }
            },
            Address = new Address
            {
                City = "Cape Town",
                Street = "Mowbray",
                PostalCode = "770"
            }
        },
              new Restaurant
              {
            Name = "McDonald’s",
            Category = "Fast Food",
            Description = "McDonald's is a fast food restaurant chain.",
            ContactNumber ="0154738459",
            ContactEmail = "contact@mcdonalds.com",
            HasDelivery = true,
            Address = new Address
            {
                City = "Cape Town",
                Street = "Cavendish",
                PostalCode = "770"
            }
        }
         ];
            return restaurants;

        }
    }
}
