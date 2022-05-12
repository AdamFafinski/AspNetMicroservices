using Discount.API.App.Presentation.ApiEndpointDefinitions;

namespace Discount.API.App.Presentation;

public static class ApiEndpointsConfig
{
    public static void ConfigureApiEndpoints(this WebApplication app)
    {
        DiscountEndpoints.Configure(app);
    }
}
