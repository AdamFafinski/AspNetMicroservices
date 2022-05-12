﻿using MediatR;

namespace Ordering.Application.Features.Queries.GetOrdersList;
public class GetOrdersListQuery : IRequest<List<OrderViewModel>>
{
    public string UserName { get; set; }
    public GetOrdersListQuery(string userName)
    {
        UserName = userName;
    }
}