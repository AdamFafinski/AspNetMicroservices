using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Features.Queries.GetOrdersList;
public class GetOrdersListQuery : IRequest<AppResponse<List<OrderViewModel>>>
{
    public string UserName { get; set; }
    public GetOrdersListQuery(string userName)
    {
        UserName = userName;
    }
}
