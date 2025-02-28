using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantDbSeeder(AppDbContext appDbContext, ILogger<RestaurantDbSeeder> logger): IRestaurantDbSeeder
{
    public async Task Seed()
    {
        var canConnect = await appDbContext.Database.CanConnectAsync();
        if (!canConnect)
        {
            // todo
            logger.LogError("Cannot connect to database");
            throw new Exception();
        }
        
        logger.LogWarning("Successfully connected to database");


        if (!appDbContext.Restaurants.Any())
        {
            logger.LogWarning("Start seeding Restaurants in database");
            var restaurant = GetRestaurants();
            await appDbContext.Restaurants.AddAsync(restaurant);
            await appDbContext.SaveChangesAsync();
            logger.LogWarning("Successfully seeded Restaurants in database");
        }
        
        logger.LogWarning("Successfully finished seeding");
    }

    private Restaurant GetRestaurants()
    {
        var restaurant = new Restaurant()
        {
            Name = "KFC",
            Category = " Fast Food",
            Description = "KFS is an American fast food restaurant",
            HasDelivery = true,
            ContactEmail = "kfc@gmail.com",
            ContactNumber = " 453627",
            Dishes = new List<Dish>()
            {
                new Dish()
                {
                    Name = "Maburger",
                    Description = "Hamburgers are very good",
                    Price = 5
                },
                new Dish()
                {
                    Name = "KFC Bucket",
                    Description = "Bucket full of chicken wings",
                    Price = 20
                }
            },
            Address = new Address()
            {
                City = "Kraków",
                Street = "slowackiego",
                PostalCode = "32-600"
            }
        };
        
        return restaurant;
    }


}