﻿using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Queries.GetOrdersList;
public class GetOrdersListQueryHandler : IRequestHandler<GetOrdersListQuery, List<OrderViewModel>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrdersListQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<List<OrderViewModel>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
    {
        var dbOrders = await _orderRepository.GerOrdersByUserNameAsync(request.UserName);
        return _mapper.Map<List<OrderViewModel>>(dbOrders);
    }
}