using Catalog.API.App.Application.Dto;
using Catalog.API.App.Application.Interfaces;
using Catalog.API.App.Application.Responses;

namespace Catalog.API.App.Presentation.ApiEndpointDefinitions
{
    public static class CatalogEndpoints
    {
        public static void Configure(WebApplication app)
        {
            const string apiBase = "api/v1/catalog";

            app.MapGet($"{apiBase}/get-products", GetProducts)
                .Produces<AppResponse<IEnumerable<ProductDto>>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapGet($"{apiBase}/get-product-by-id/{{id:length(24)}}", GetProductById)
                .Produces<AppResponse<ProductDto>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapGet($"{apiBase}/get-products-by-category/{{categoryName}}", GetProductsByCategory)
                .Produces<AppResponse<AppResponse<IEnumerable<ProductDto>>>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapGet($"{apiBase}/get-products-by-name/{{productName}}", GetProductsByName)
                .Produces<AppResponse<AppResponse<IEnumerable<ProductDto>>>>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapPost($"{apiBase}/create-product", CreateProduct)
                .Produces<AppResponse>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapDelete($"{apiBase}/delete-product/{{id:length(24)}}", DeleteProduct)
                .Produces<AppResponse>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

            app.MapPut($"{apiBase}/update-product", UpdateProduct)
                .Produces<AppResponse>(StatusCodes.Status200OK)
                .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
                .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);
        }

        private async static Task<IResult> GetProducts(IProductService productService)
        {
            var responseData = await productService.GetProducts();
            return Results.Ok(responseData);
        }

        private async static Task<IResult> GetProductById(string id, IProductService productService)
        {
            var responseData = await productService.GetProductById(id);
            return Results.Ok(responseData);
        }

        private async static Task<IResult> CreateProduct(ProductDto product, IProductService productService)
        {
            await productService.CreateProduct(product);
            return Results.Ok();
        }

        private async static Task<IResult> DeleteProduct(string id, IProductService productService)
        {
            var responseData = await productService.DeleteProduct(id);
            return Results.Ok(responseData);
        }

        private async static Task<IResult> GetProductsByCategory(string categoryName, IProductService productService)
        {
            var responseData = await productService.GetProductsByCategory(categoryName);
            return Results.Ok(responseData);
        }

        private async static Task<IResult> GetProductsByName(string productName, IProductService productService)
        {
            var responseData = await productService.GetProductsByName(productName);
            return Results.Ok(responseData);
        }

        private async static Task<IResult> UpdateProduct(ProductDto product, IProductService productService)
        {
            var responseData = await productService.UpdateProduct(product);
            return Results.Ok(responseData);
        }
    }
}
