using AutoMapper;
using FluentAssertions;
using Restaurants.Application.Commands.CreateRestaurant;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Models;
using Xunit;

namespace Restaurants.Application.Mapping.Tests
{
    public class RestaurantsProfileTests
    {
        [Fact()]
        public void CreateMap_ForRestaurantToRestaurantDto_MapsCorrectly()
        {
            //arrage

            var configuration = new MapperConfiguration(cfg =>
            
            {
                cfg.AddProfile<RestaurantsProfile>();
            });

            var mapper = configuration.CreateMapper();

            var restaurant = new Restaurant()
            {
                Id = new Guid(),
                Name = "Test restaurant",
                Description = "Test Description",
                Category = "Test Category",
                HasDelivery = true,
                ContactEmail = "devTesting@gmail.com",
                ContactNumber = "0719710893",
                Address = new Address
                {
                    City = "Test city",
                    Street = "Test street",
                    PostalCode = "0744"
                }

            };

            //act
            var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

            //assert

            restaurantDto.Should().NotBeNull();
            restaurantDto.Id.Should().Be(restaurant.Id);
            restaurantDto.Name.Should().Be(restaurant.Name);
            restaurantDto.Description.Should().Be(restaurant.Description);
            restaurantDto.Category.Should().Be(restaurant.Category);
            restaurantDto.HasDelivery.Should().Be(restaurant.HasDelivery);
            restaurantDto.City.Should().Be(restaurant.Address.City);
        }

        [Fact()]
        public void CreateMap_ForCreateRestaurantCommandToRestaurant_MapsCorrectly()
        {
            //arrage

            var configuration = new MapperConfiguration(cfg =>

            {
                cfg.AddProfile<RestaurantsProfile>();
            });

            var mapper = configuration.CreateMapper();

            var command = new CreateRestaurantCommand()
            {
                
               Name = "Test restaurant",
                Description = "Test Description",
                Category = "Test Category",
                HasDelivery =true,
                ContactEmail = "devTesting@gmail.com",
                ContactNumber = "0719710893",
                City ="Test city",
                Street ="Test street",
                PostalCode ="00990"
               

            };

            //act
            var restaurant = mapper.Map<Restaurant>(command);

            //assert

            restaurant.Should().NotBeNull();
            restaurant.Name.Should().Be(command.Name);
            restaurant.Description.Should().Be(command.Description);
            restaurant.Category.Should().Be(command.Category);
            restaurant.HasDelivery.Should().Be(command.HasDelivery);
            restaurant.ContactNumber.Should().Be(command.ContactNumber);
            restaurant.ContactEmail.Should().Be(command.ContactEmail);
            restaurant.Address.Should().NotBeNull();
            restaurant.Address.City.Should().Be(command.City);
            restaurant.Address.Street.Should().Be(command.Street);
            restaurant.Address.PostalCode.Should().Be(command.PostalCode);
        }


    }
}