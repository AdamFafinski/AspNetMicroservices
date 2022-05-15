using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Exceptions;
using Ordering.Application.Features.Commands.CheckoutOrder;
using Ordering.Application.Responses;
using System.Net;

namespace Ordering.Application.Features.Commands.UpdateOrder;
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, AppResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public UpdateOrderCommandHandler(
        IOrderRepository orderRepository,
        IMapper mapper,
        ILogger<CheckoutOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<AppResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var dbOrder = await _orderRepository.GetByIdAsync(request.Id);
        if (dbOrder is null)
            throw new AppException(HttpStatusCode.NotFound, $"Order {request.Id} not found");

        _mapper.Map(request, dbOrder);

        await _orderRepository.UpdateAsync(dbOrder);
        _logger.LogInformation("Order {OrderId} was succesfully updated.", dbOrder.Id);

        return new AppResponse(true, "Order updated");
    }
}
