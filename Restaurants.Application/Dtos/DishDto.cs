using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dtos;

public class DishDto
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;
    
    public decimal Price { get; set; }
    

    public static DishDto FromEntity(Dish dish)
    {
        var dto = new DishDto()
        {
            Id = dish.Id,
            Name = dish.Name,
            Description = dish.Description,
            Price = dish.Price,
        };

        return dto;
    }
    
}