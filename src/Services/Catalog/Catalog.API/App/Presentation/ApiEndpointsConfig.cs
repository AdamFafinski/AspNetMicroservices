using Catalog.API.App.Presentation.ApiEndpointDefinitions;

namespace Catalog.API.App.Presentation
{
    public static class ApiEndpointsConfig
    {
        public static void ConfigureApiEndpoints(this WebApplication app)
        {
            CatalogEndpoints.Configure(app);
        }
    }
}
