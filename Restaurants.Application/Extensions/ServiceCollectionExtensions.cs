using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Services;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationModuleDependencies(this IServiceCollection service)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        service.AddScoped<IRestaurantService, RestaurantsService>();
        service.AddAutoMapper(assembly);
        // service.AddScoped<IValidator<CreateRestaurantDto>, CreateRestaurantDtoValidator>();

        service.AddValidatorsFromAssembly(assembly).AddFluentValidationAutoValidation();
        return service;
    }
}