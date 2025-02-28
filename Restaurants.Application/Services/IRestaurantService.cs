
using Restaurants.Application.Dtos;

namespace Restaurants.Application.Services;

public interface IRestaurantService
{
    public Task<List<RestaurantDto>> GetAll();
    public Task<RestaurantDto?> GetById(int id);
    public Task<int> CreateRestaurant(CreateRestaurantDto dto);

}