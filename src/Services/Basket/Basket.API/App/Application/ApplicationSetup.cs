using Basket.API.App.Application.Interfaces;
using Basket.API.App.Application.Services;
using System.Reflection;

namespace Basket.API.App.Application;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddScoped<IBasketService, BasketService>();

        return services;
    }
}
