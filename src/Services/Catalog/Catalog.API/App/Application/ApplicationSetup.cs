using Catalog.API.App.Application.Interfaces;
using Catalog.API.App.Application.Services;
using System.Reflection;

namespace Catalog.API.App.Application
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
