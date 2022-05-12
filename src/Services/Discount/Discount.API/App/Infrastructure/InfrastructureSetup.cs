using Discount.API.App.Application.Interfaces;
using Discount.API.App.Infrastructure.Repositories;

namespace Discount.API.App.Infrastructure;

public static class InfrastructureSetup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IDiscountRepository, DiscountRepository>();

        return services;
    }
}
