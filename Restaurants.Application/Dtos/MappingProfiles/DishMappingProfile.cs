using AutoMapper;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dtos.MappingProfiles;

public class DishMappingProfile: Profile
{
    public DishMappingProfile()
    {
        CreateMap<Dish, DishDto>();
    }
    
}