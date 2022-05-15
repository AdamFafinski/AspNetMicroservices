using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Commands.CheckoutOrder;
using Ordering.Application.Features.Commands.DeleteOrder;
using Ordering.Application.Features.Commands.UpdateOrder;
using Ordering.Application.Features.Queries.GetOrdersList;
using Ordering.Application.Models;
using Ordering.Application.Responses;

namespace Ordering.API.EndpointsDefinitions;

public static class OrderingEndpoints
{
    public static void ConfigureOrderingEndpoints(this WebApplication app)
    {
        const string apiBase = "api/v1/order";

        app.MapGet($"{apiBase}/get-orders-by-user-name/{{userName}}", GetOrdersByUserName)
            .Produces<AppResponse<List<OrderViewModel>>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapPost($"{apiBase}/checkout-order", CheckoutOrder)
            .Produces<AppResponse<int>>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapPut($"{apiBase}/update-order", UpdateOrder)
            .Produces<AppResponse>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

        app.MapDelete($"{apiBase}/delete-order/{{id}}", DeleteOrder)
            .Produces<AppResponse>(StatusCodes.Status200OK)
            .Produces<AppResponse<AppError>>(StatusCodes.Status500InternalServerError);

    }
    private async static Task<IResult> GetOrdersByUserName(string userName, IMediator mediator) =>
        Results.Ok(await mediator.Send(new GetOrdersListQuery(userName)));

    private async static Task<IResult> CheckoutOrder(CheckoutOrderCommand checkoutOrderCommand, IMediator mediator) =>
        Results.Ok(await mediator.Send(checkoutOrderCommand));

    private async static Task<IResult> UpdateOrder([FromBody]UpdateOrderCommand updateOrderCommand, IMediator mediator) =>
        Results.Ok(await mediator.Send(updateOrderCommand));

    private async static Task<IResult> DeleteOrder(int id, IMediator mediator) =>
        Results.Ok(await mediator.Send(new DeleteOrderCommand { Id = id }));
}
