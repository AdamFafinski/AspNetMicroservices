using Basket.API.App.Application.Dto;
using Basket.API.App.Application.Interfaces;
using Basket.API.App.Application.Responses;

namespace Basket.API.App.Presentation.ApiEndpointsDefinitions;

public static class BasketEndpoints
{
    public static void Configure(WebApplication app)
    {
        const string apiBasketBase = "api/v1/catalog";

        app.MapGet($"{apiBasketBase}/get-basket/{{userName}}", GetBasket)
            .Produces<AppResponse<ShoppingCartDto>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapPost($"{apiBasketBase}/update-basket", UpdateBasket)
            .Produces<AppResponse<ShoppingCartDto>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapDelete($"{apiBasketBase}/delete-basket/{{userName}}", DeleteBasket)
            .Produces<AppResponse>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);
    }

    private static async Task<IResult> GetBasket(string userName, IBasketService basketService)
    {
        var data = await basketService.GetBasket(userName);
        return Results.Ok(data);
    }

    private static async Task<IResult> UpdateBasket(ShoppingCartDto basket, IBasketService basketService)
    {
        var data = await basketService.UpdateBasket(basket);
        return Results.Ok(data);
    }

    private static async Task<IResult> DeleteBasket(string userName, IBasketService basketService)
    {
        var data = await basketService.DeleteBasket(userName);
        return Results.Ok(data);
    }
}