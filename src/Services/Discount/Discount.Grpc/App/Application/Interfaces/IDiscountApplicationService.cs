using Discount.Grpc.Shared.Contracts;

namespace Discount.Grpc.App.Application.Interfaces;

public interface IDiscountApplicationService
{
    Task<CouponModel> GetDiscountAsync(string productName);
    Task<CouponModel> CreateDiscountAsync(CouponModel discount);
    Task<CouponModel> UpdateDiscountAsync(CouponModel discount);
    Task<IsSuccessModel> DeleteDiscountAsync(string productName);
}
