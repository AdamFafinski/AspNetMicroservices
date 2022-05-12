using AutoMapper;
using Discount.API.App.Application.Dto;
using Discount.API.App.Application.Exceptions;
using Discount.API.App.Application.Interfaces;
using Discount.API.App.Application.Responses;
using Discount.API.App.Domain.Entities;
using System.Net;

namespace Discount.API.App.Application.Services;

public class DiscountService : IDiscountService
{
    private readonly IMapper _mapper;
    private readonly IDiscountRepository _discountRepository;

    public DiscountService(IMapper mapper, IDiscountRepository discountRepository)
    {
        _mapper = mapper;
        _discountRepository = discountRepository;
    }
    public async Task<AppResponse<CouponDto>> CreateDiscount(CouponDto discount)
    {
        var newDiscount = _mapper.Map<Coupon>(discount);
        await _discountRepository.CreateDiscount(newDiscount);

        return await GetDiscount(discount.ProductName);
    }

    public async Task<AppResponse> DeleteDiscount(string productName)
    {
        var isDeleted = await _discountRepository.DeleteDiscount(productName);
        if (isDeleted)
            return new AppResponse(true, "Operation Success");

        throw new AppException(HttpStatusCode.NotFound, "Product not found.");
    }

    public async Task<AppResponse<CouponDto>> GetDiscount(string productName)
    {
        var dbDiscount = await _discountRepository.GetDiscount(productName);
        if (dbDiscount is null)
            throw new AppException(HttpStatusCode.NotFound, "Discount not found.");

        var mappedDiscount = _mapper.Map<CouponDto>(dbDiscount);
        return new AppResponse<CouponDto>(true, mappedDiscount, "Operation Success.");
    }

    public async Task<AppResponse> UpdateDiscount(CouponDto discount)
    {
        var discountToUpdate = _mapper.Map<Coupon>(discount);
        var isUpdated = await _discountRepository.UpdateDiscount(discountToUpdate);
        if (isUpdated)
            return new AppResponse(true, "Operation Success.");

        throw new AppException(HttpStatusCode.InternalServerError, "Operation fail.");
    }
}
