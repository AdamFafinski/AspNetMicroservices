using Basket.API.App.Application.Dto;
using Basket.API.App.Application.Responses;

namespace Basket.API.App.Application.Interfaces;

public interface IBasketService
{
    Task<AppResponse> DeleteBasket(string userName);
    Task<AppResponse<ShoppingCartDto>> GetBasket(string userName);
    Task<AppResponse<ShoppingCartDto>> UpdateBasket(ShoppingCartDto basket);
}