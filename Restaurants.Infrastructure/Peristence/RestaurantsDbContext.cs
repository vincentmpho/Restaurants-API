using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Models;

namespace Restaurants.Infrastructure.Peristence
{
    public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) 
        : IdentityDbContext<User>(options)
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder) 
        {
            base.OnModelCreating(ModelBuilder);

            ModelBuilder.Entity<Restaurant>()
                        .OwnsOne(r => r.Address);

            ModelBuilder.Entity<Restaurant>()
                         .HasMany(r => r.Dishes)
                          .WithOne()
                          .HasForeignKey(d => d.RestaurantId);
        }
    }

}
