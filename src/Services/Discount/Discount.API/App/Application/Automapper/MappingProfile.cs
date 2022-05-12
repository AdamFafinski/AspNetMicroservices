using AutoMapper;
using Discount.API.App.Application.Dto;
using Discount.API.App.Domain.Entities;

namespace Discount.API.App.Application.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Coupon, CouponDto>()
            .ReverseMap();
    }
}
