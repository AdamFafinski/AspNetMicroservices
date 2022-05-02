using Catalog.API.App.Application.Interfaces;
using Catalog.API.App.Infrastructure.Persistence;
using Catalog.API.App.Infrastructure.Repositories;

namespace Catalog.API.App.Infrastructure.Application;

public static class InfrastructureSetup
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services
            .AddScoped<ICatalogContext, CatalogContext>()
            .AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
