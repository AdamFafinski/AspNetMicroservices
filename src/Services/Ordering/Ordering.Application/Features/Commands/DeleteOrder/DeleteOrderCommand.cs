using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Features.Commands.DeleteOrder;
public class DeleteOrderCommand : IRequest<AppResponse>
{
    public int Id { get; set; }
}
