using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exceptions;
using Ordering.Application.Responses;
using System.Net;

namespace Ordering.Application.Features.Commands.DeleteOrder;
public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, AppResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<DeleteOrderCommandHandler> _logger;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }
    public async Task<AppResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var dbOrder = await _orderRepository.GetByIdAsync(request.Id);
        if (dbOrder is null)
            throw new AppException(HttpStatusCode.NotFound, $"Order {request.Id} not found");

        await _orderRepository.DeleteAsync(dbOrder);
        _logger.LogInformation("Order successfully deleted.");

        return new AppResponse(true, "Order successfully deleted.");
    }
}
