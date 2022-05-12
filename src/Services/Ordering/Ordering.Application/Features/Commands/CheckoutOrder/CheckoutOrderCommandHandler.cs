using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Infrastructure;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Commands.CheckoutOrder;
public class CheckoutOrderCommandHandler : IRequestHandler<CheckoutOrderCommand, int>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CheckoutOrderCommandHandler> _logger;

    public CheckoutOrderCommandHandler(
        IOrderRepository orderRepository, 
        IMapper mapper, 
        IEmailService emailService,
        ILogger<CheckoutOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }
    public async Task<int> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
    {
        var newOrder = _mapper.Map<Order>(request);

        var newDbOrder = await _orderRepository.AddAsync(newOrder);

        _logger.LogInformation("New order {OrderId} was successfully created. ", newDbOrder.Id);

        await SendEmail(newDbOrder);

        return newDbOrder.Id;
    }

    private async Task SendEmail(Order newDbOrder)
    {
        var email = new Email() { To = "ezozkme@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

        try
        {
            await _emailService.SendEmail(email);
        }
        catch (Exception ex)
        {
            _logger.LogError("Order {OrderId} failed due to an error with the mail service: {ExceptionMessage}", newDbOrder.Id, ex.Message);
        }
    }
}
