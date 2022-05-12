using Discount.Grpc.App.Application.Interfaces;
using Discount.Grpc.Shared.Contracts;
using ProtoBuf.Grpc;

namespace Discount.Grpc.App.Presentation.GrpcServices;

public class DiscountService : IDiscountService
{
    private readonly IDiscountApplicationService _discountApplicationService;

    public DiscountService(IDiscountApplicationService discountApplicationService)
    {
        _discountApplicationService = discountApplicationService;
    }

    public async Task<CouponModel> GetDiscountAsync(GetDiscountRequest discountRequest, CallContext context = default) =>
        await _discountApplicationService.GetDiscountAsync(discountRequest.ProductName);

    public async Task<CouponModel> CreateDiscountAsync(CreateDiscountRequest createDiscountRequest, CallContext context = default) =>
        await _discountApplicationService.CreateDiscountAsync(createDiscountRequest.Coupon);

    public async Task<CouponModel> UpdateDiscountAsync(UpdateDiscountRequest updateDiscountRequest, CallContext context = default) =>
        await _discountApplicationService.UpdateDiscountAsync(updateDiscountRequest.Coupon);

    public async Task<IsSuccessModel> DeleteDiscountAsync(DeleteDiscountRequest deleteDiscountRequest, CallContext context = default) =>
        await _discountApplicationService.DeleteDiscountAsync(deleteDiscountRequest.ProductName);

}