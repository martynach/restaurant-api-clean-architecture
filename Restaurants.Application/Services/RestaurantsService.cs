using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;

namespace Restaurants.Application.Services;

internal class RestaurantsService(ILogger <RestaurantsService> logger,
    IRestaurantRepository restaurantRepository,
    IMapper mapper): IRestaurantService
{
    public async Task<List<RestaurantDto>> GetAll()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantRepository.GetAllRestaurants();
        var dtos = mapper.Map<List<RestaurantDto>>(restaurants);
        return dtos!;
    }

    public async Task<RestaurantDto?> GetById(int id)
    {
        logger.LogInformation($"Getting restaurant with id: {id}");
        var restaurant = await restaurantRepository.GetRestaurantById(id);
        var dto = mapper.Map<RestaurantDto>(restaurant);
        return dto;

    }

    public async Task<int> CreateRestaurant(CreateRestaurantDto dto)
    {
        logger.LogInformation($"Creating new restaurant");
        // var validationResult = await validator.ValidateAsync(dto);
        // if (!validationResult.IsValid)
        // {
        //     // todo
        //     logger.LogError($"Validation failed: {validationResult.Errors}");
        //     throw new Exception(validationResult.Errors.ToString());
        //
        //
        // }
        var entity = mapper.Map<Restaurant>(dto);
        var id = await restaurantRepository.CreateRestaurant(entity);
        return id;
    }
}