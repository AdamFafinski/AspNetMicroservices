using Discount.Grpc.Shared.Contracts;

namespace Discount.Grpc.App.Application.Interfaces;

public interface IDiscountRepository
{
    Task<CouponModel> GetDiscountAsync(string productNam);
    Task<bool> CreateDiscountAsync(CouponModel coupon);
    Task<bool> UpdateDiscountAsync(CouponModel coupon);
    Task<bool> DeleteDiscountAsync(string productName);
}
