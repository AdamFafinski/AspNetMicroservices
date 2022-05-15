using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence;
public class OrderContextSeed
{
    public static async Task SeedAsync(
        OrderDbContext orderDbContext,
        ILogger<OrderContextSeed> logger)
    {
        if (!orderDbContext.Orders.Any())
        {
            orderDbContext.Orders.AddRange(GetPreconfiguredOrders());
            await orderDbContext.SaveChangesAsync();
            logger.LogInformation("Seed database associated with context {DbContext}", typeof(OrderDbContext).Name);
        }
    }

    private static IEnumerable<Order> GetPreconfiguredOrders()
    {
        return new List<Order>
        {
            new Order()
            {
                UserName = "swn",
                FirstName = "Mehmet",
                LastName = "Ozkaya",
                EmailAddress = "ezozkme@gmail.com",
                AddressLine = "Bahcelievler",
                Country = "Turkey",
                TotalPrice = 350,
                State = string.Empty,
                ZipCode =string.Empty, 
                CardName =string.Empty,
                CardNumber =string.Empty,
                Expiration =string.Empty,
                CVV =string.Empty,
                PaymentMethod = 1,
                LastModifiedBy = string.Empty,
            }

        };
    }
}
