using Discount.Grpc.App.Application.Interfaces;
using Discount.Grpc.App.Infrastructure.Repositories;

namespace Discount.Grpc.App.Infrastructure;

public static class InfrastructureSetup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddScoped<IDiscountRepository, DiscountRepository>();

        return services;
    }
}
