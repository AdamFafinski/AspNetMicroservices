using Discount.API.App.Application.Dto;
using Discount.API.App.Application.Responses;

namespace Discount.API.App.Application.Interfaces;

public interface IDiscountService
{
    Task<AppResponse<CouponDto>> GetDiscount(string productName);
    Task<AppResponse<CouponDto>> CreateDiscount(CouponDto discount);
    Task<AppResponse> UpdateDiscount(CouponDto discount);
    Task<AppResponse> DeleteDiscount(string productName);
}
