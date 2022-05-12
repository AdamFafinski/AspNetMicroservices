using Discount.Grpc.App.Application.Interfaces;
using Discount.Grpc.App.Application.Services;
using System.Reflection;

namespace Discount.Grpc.App.Application;

public static class ApplicationSetup
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<IDiscountApplicationService, DiscountApplicationService>();

        return services;
    }
}
