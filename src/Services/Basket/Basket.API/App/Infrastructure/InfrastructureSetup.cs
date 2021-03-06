using Basket.API.App.Application.Interfaces;
using Basket.API.App.Infrastructure.Repositories;
using Basket.API.App.Infrastructure.Services;

namespace Basket.API.App.Infrastructure;

public static class InfrastructureSetup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddScoped<IBasketRepository, BasketRepository>()
            .AddScoped<IDiscountGrpcService, DiscountGrpcService>()
            .AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetValue<string>("CacheSettings:ConnectionString");
            });

        return services;
    }
}
