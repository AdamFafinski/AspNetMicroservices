using Basket.API.App.Application.Dto;
using Basket.API.App.Application.Interfaces;
using Basket.API.App.Application.Responses;

namespace Basket.API.App.Presentation.ApiEndpointsDefinitions;

public static class BasketEndpoints
{
    public static void Configure(WebApplication app)
    {
        const string apiBase = "api/v1/basket";

        app.MapGet($"{apiBase}/get-basket/{{userName}}", GetBasket)
            .Produces<AppResponse<ShoppingCartDto>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapPost($"{apiBase}/update-basket", UpdateBasket)
            .Produces<AppResponse<ShoppingCartDto>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapDelete($"{apiBase}/delete-basket/{{userName}}", DeleteBasket)
            .Produces<AppResponse>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);
    }

    private async static Task<IResult> GetBasket(string userName, IBasketService basketService)
    {
        var responseData = await basketService.GetBasket(userName);
        return Results.Ok(responseData);
    }

    private async static Task<IResult> UpdateBasket(ShoppingCartDto basket, IBasketService basketService)
    {
        var responseData = await basketService.UpdateBasket(basket);
        return Results.Ok(responseData);
    }

    private async static Task<IResult> DeleteBasket(string userName, IBasketService basketService)
    {
        var responseData = await basketService.DeleteBasket(userName);
        return Results.Ok(responseData);
    }
}