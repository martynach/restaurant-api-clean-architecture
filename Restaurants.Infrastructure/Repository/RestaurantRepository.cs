using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repository;

internal class RestaurantRepository(AppDbContext appDbContext) : IRestaurantRepository
{
    public async Task<List<Restaurant>> GetAllRestaurants()
    {
        return await appDbContext.Restaurants.ToListAsync();
    }

    public async Task<Restaurant?> GetRestaurantById(int id)
    {
        return await appDbContext
            .Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<int> CreateRestaurant(Restaurant restaurant)
    {
        var result = await appDbContext.Restaurants.AddAsync(restaurant);
        await appDbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

}