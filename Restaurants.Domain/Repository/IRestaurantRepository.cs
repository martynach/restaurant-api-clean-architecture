using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repository;

public interface IRestaurantRepository
{
    public Task<List<Restaurant>> GetAllRestaurants();
    public Task<Restaurant?> GetRestaurantById(int id);
    public Task<int> CreateRestaurant(Restaurant restaurant);
}