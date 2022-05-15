using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistance;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories;
public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    public OrderRepository(OrderDbContext orderDbContext) : base(orderDbContext) { }

    public async Task<IEnumerable<Order>> GerOrdersByUserNameAsync(string userName)
    {
        return await _orderDbContext.Orders
            .Where(o => o.UserName == userName)
            .ToListAsync();
    }
}
