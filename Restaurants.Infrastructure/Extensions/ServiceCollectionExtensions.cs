using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repository;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Repository;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("RestaurantDbConnectionString");
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IRestaurantDbSeeder, RestaurantDbSeeder>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
    }
}