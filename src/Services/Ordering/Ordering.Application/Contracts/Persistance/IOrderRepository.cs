﻿using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts.Persistance;
public interface IOrderRepository : IAsyncRepository<Order> 
{
    Task<IEnumerable<Order>> GerOrdersByUserNameAsync(string userName);
}
