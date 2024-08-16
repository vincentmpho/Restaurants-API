using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Interfaces.Repositories;
using Restaurants.Infrastructure.Peristence;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Seeders;
using Restaurants.Infrastructure.Seeders.Interfaces;

namespace Restaurants.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RestaurantDb");
            services.AddDbContext<RestaurantsDbContext>(options =>
            options.UseNpgsql(connectionString)
            .EnableSensitiveDataLogging());


            services.AddScoped<IResturantSeeder, ResturantSeeder>();
            // Register repositories
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IDishesRepository, DishesRepository>();

        }
    }
}
