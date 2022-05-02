using Basket.API.App.Domain.Entities;

namespace Basket.API.App.Application.Interfaces;

public interface IBasketRepository
{
    Task<ShoppingCart?> GetBasket(string userName);
    Task<ShoppingCart?> UpdateBasket(ShoppingCart basket);
    Task DeleteBasket(string userName);
}
