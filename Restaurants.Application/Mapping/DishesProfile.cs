using AutoMapper;
using Restaurants.Application.DTOs;
using Restaurants.Domain.Models;

namespace Restaurants.Application.Mapping
{
    public class DishesProfile : Profile
    {
        public DishesProfile()
        {
            //From Source Type, Destination type
            CreateMap<Dish , DishDto>();
        }
    }
}
