using Basket.API.App.Presentation.ApiEndpointsDefinitions;

namespace Basket.API.App.Presentation;

public static class ApiEndpointsConfig
{
    public static void ConfigureApiEndpoints(this WebApplication app)
    {
        BasketEndpoints.Configure(app);
    }
}
