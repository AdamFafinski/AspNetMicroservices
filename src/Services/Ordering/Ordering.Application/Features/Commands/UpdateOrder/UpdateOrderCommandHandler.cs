using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Features.Commands.CheckoutOrder;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Commands.UpdateOrder;
public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
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

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var dbOrder = await _orderRepository.GetByIdAsync(request.Id);
        if (dbOrder is null)
        {
            _logger.LogError("Order doesn't exist in database.");
        }

        _mapper.Map<UpdateOrderCommand, Order>(request, dbOrder);

        await _orderRepository.UpdateAsync(dbOrder);
        _logger.LogInformation("Order {OrderId} was succesfully updated.", dbOrder.Id);

        return Unit.Value;
    }
}
