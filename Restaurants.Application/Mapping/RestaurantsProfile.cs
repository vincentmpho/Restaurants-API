using AutoMapper;
using Restaurants.Application.Commands.CreateRestaurant;
using Restaurants.Application.Commands.UpdateRestaurant;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Mapping
{
    public class RestaurantsProfile : Profile
    {
        public RestaurantsProfile()
        {
            CreateMap<UpdateRestaurantCommand, Restaurant>();

            CreateMap<CreateRestaurantCommand, Restaurant>()
                .ForMember(d => d.Address, opt=> opt.MapFrom(
                    src => new Address
                    {
                        City = src.City,
                        PostalCode = src.PostalCode,
                        Street = src.Street
                    }));


            //From Source Type, Destination type
            CreateMap<Restaurant, RestaurantDto>()

                // Map the City property of RestaurantDto from the City property of the Address in Restaurant
                .ForMember(d => d.City, opt =>
                   opt.MapFrom(src => src.Address == null ? null : src.Address.City))

                // Map the PostalCode property of RestaurantDto from the PostalCode property of the Address in Restaurant
                .ForMember(d => d.PostalCode, opt =>
                   opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))

                // Map the Street property of RestaurantDto from the Street property of the Address in Restaurant
                .ForMember(d => d.Street, opt =>
                   opt.MapFrom(src => src.Address == null ? null : src.Address.Street))

                // Map the Dishes property of RestaurantDto directly from the Dishes property of Restaurant
                .ForMember(d => d.Dishes, opt =>
                   opt.MapFrom(src => src.Dishes));
        }
    }
}
