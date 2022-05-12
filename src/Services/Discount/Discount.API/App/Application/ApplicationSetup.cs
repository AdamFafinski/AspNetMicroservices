using Discount.API.App.Application.Interfaces;
using Discount.API.App.Application.Services;
using System.Reflection;

namespace Discount.API.App.Application;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddScoped<IDiscountService, DiscountService>();

        return services;
    }
}
