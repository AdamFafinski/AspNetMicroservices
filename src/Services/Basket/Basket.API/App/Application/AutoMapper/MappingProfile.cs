using AutoMapper;
using Basket.API.App.Application.Dto;
using Basket.API.App.Domain.Entities;

namespace Basket.API.App.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ReverseMap();
        CreateMap<ShoppingCartItem, ShoppingCartItemDto>()
            .ReverseMap();
    }
}
