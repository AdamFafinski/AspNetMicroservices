using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using Ordering.Application.Responses;

namespace Ordering.Application.Features.Queries.GetOrdersList;
public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, AppResponse<List<OrderViewModel>>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<AppResponse<List<OrderViewModel>>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
    {
        var dbOrders = await _orderRepository.GerOrdersByUserNameAsync(request.UserName);

        var orders = _mapper.Map<List<OrderViewModel>>(dbOrders);

        return new AppResponse<List<OrderViewModel>>(true, orders);
    }
}
