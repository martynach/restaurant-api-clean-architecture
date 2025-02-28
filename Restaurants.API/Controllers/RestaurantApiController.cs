using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dtos;
using Restaurants.Application.Services;

namespace Restaurants.API.Controllers;

[ApiController]
[Route("api/restaurant")]
public class RestaurantApiController(IRestaurantService restaurantService): ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dtos = await restaurantService.GetAll();
        return Ok(dtos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dto = await restaurantService.GetById(id);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto dto)
    {
        var id = await restaurantService.CreateRestaurant(dto);
        // return Created($"api/restaurant/{id}", null);
        return CreatedAtAction(nameof(GetById),new {id}, null);
    }
    
}