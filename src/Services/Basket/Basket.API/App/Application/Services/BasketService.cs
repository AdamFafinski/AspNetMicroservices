using AutoMapper;
using Basket.API.App.Application.Dto;
using Basket.API.App.Application.Interfaces;
using Basket.API.App.Application.Responses;
using Basket.API.App.Domain.Entities;

namespace Basket.API.App.Application.Services;

public class BasketService : IBasketService
{
    private readonly IMapper _mapper;
    private readonly IBasketRepository _basketRepository;

    public BasketService(IMapper mapper, IBasketRepository basketRepository)
    {
        _mapper = mapper;
        _basketRepository = basketRepository;
    }
    public async Task<AppResponse> DeleteBasket(string userName)
    {
        await _basketRepository.DeleteBasket(userName);
        return new AppResponse(true, "Basket deleted.");
    }

    public async Task<AppResponse<ShoppingCartDto>> GetBasket(string userName)
    {
        var dbBasket = await _basketRepository.GetBasket(userName);

        var basket = dbBasket is null ? new() : _mapper.Map<ShoppingCartDto>(dbBasket);
        
        return new AppResponse<ShoppingCartDto>(true, basket);
    }

    public async Task<AppResponse<ShoppingCartDto>> UpdateBasket(ShoppingCartDto basket)
    {
        var basketToUpdate = _mapper.Map<ShoppingCart>(basket);
        await _basketRepository.UpdateBasket(basketToUpdate);
        return await GetBasket(basket.UserName);
    }
}
