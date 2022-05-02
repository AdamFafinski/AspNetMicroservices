using Catalog.API.App.Application.Dto;
using Catalog.API.App.Application.Interfaces;
using Catalog.API.App.Application.Responses;

namespace Catalog.API.App.Presentation.ApiEndpointDefinitions
{
    public static class CatalogEndpoints
    {
        public static void Configure(WebApplication app)
        {
            const string apiCatalogBase = "api/v1/catalog";

            app.MapGet($"{apiCatalogBase}/get-products", GetProducts)
                .Produces<AppResponse<IEnumerable<ProductDto>>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapGet($"{apiCatalogBase}/get-product-by-id/{{id:length(24)}}", GetProductById)
                .Produces<AppResponse<ProductDto>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapGet($"{apiCatalogBase}/get-products-by-category/{{categoryName}}", GetProductsByCategory)
                .Produces<AppResponse<AppResponse<IEnumerable<ProductDto>>>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapGet($"{apiCatalogBase}/get-products-by-name/{{productName}}", GetProductsByName)
                .Produces<AppResponse<AppResponse<IEnumerable<ProductDto>>>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapPost($"{apiCatalogBase}/create-product", CreateProduct)
                .Produces<AppResponse>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapDelete($"{apiCatalogBase}/delete-product/{{id:length(24)}}", DeleteProduct)
                .Produces<AppResponse>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapPut($"{apiCatalogBase}/update-product", UpdateProduct)
                .Produces<AppResponse>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);
        }

        private static async Task<IResult> GetProducts(IProductService productService)
        {
            var products = await productService.GetProducts();
            return Results.Ok(products);
        }

        private static async Task<IResult> GetProductById(string id, IProductService productService)
        {
            var product = await productService.GetProductById(id);
            return Results.Ok(product);
        }

        private static async Task<IResult> CreateProduct(ProductDto product, IProductService productService)
        {
            await productService.CreateProduct(product);
            return Results.Ok();
        }

        private static async Task<IResult> DeleteProduct(string id, IProductService productService)
        {
            var result = await productService.DeleteProduct(id);
            return Results.Ok(result);
        }

        private static async Task<IResult> GetProductsByCategory(string categoryName, IProductService productService)
        {
            var products = await productService.GetProductsByCategory(categoryName);
            return Results.Ok(products);
        }

        private static async Task<IResult> GetProductsByName(string productName, IProductService productService)
        {
            var products = await productService.GetProductsByName(productName);
            return Results.Ok(products);
        }

        private static async Task<IResult> UpdateProduct(ProductDto product, IProductService productService)
        {
            var result = await productService.UpdateProduct(product);
            return Results.Ok(result);
        }
    }
}
