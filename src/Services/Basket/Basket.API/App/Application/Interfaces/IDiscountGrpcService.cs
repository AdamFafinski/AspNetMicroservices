using Discount.Grpc.Shared.Contracts;

namespace Basket.API.App.Application.Interfaces;

public interface IDiscountGrpcService
{
    Task<CouponModel> GetDiscountAsync(GetDiscountRequest getDiscountRequest);
}