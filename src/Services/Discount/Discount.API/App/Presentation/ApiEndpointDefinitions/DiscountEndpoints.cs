using Discount.API.App.Application.Dto;
using Discount.API.App.Application.Interfaces;
using Discount.API.App.Application.Responses;

namespace Discount.API.App.Presentation.ApiEndpointDefinitions;

public class DiscountEndpoints
{
    public static void Configure(WebApplication app)
    {
        const string apiBase = "api/v1/discount";

        app.MapGet($"{apiBase}/get-discount/{{productName}}", GetDiscount)
            .Produces<AppResponse<CouponDto>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapPost($"{apiBase}/create-discount", CreateDiscount)
            .Produces<AppResponse<CouponDto>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapPut($"{apiBase}/update-discount", UpdateDiscount)
            .Produces<AppResponse>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status404NotFound)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapDelete($"{apiBase}/delete-discount/{{productName}}", DeleteDiscount)
            .Produces<AppResponse>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);
    }

    private async static Task<IResult> GetDiscount(string productName, IDiscountService discountService)
    {
        var responseData = await discountService.GetDiscount(productName);
        return Results.Ok(responseData);
    }

    private async static Task<IResult> CreateDiscount(CouponDto discount, IDiscountService discountService)
    {
        var responseData = await discountService.CreateDiscount(discount);
        return Results.Ok(responseData);
    }

    private async static Task<IResult> UpdateDiscount(CouponDto discount, IDiscountService discountService)
    {
        var responseData = await discountService.UpdateDiscount(discount);
        return Results.Ok(responseData);
    }

    private async static Task<IResult> DeleteDiscount(string productName, IDiscountService discountService)
    {
        var responseData = await discountService.DeleteDiscount(productName);
        return Results.Ok(responseData);
    }
}
