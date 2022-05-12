using Discount.Grpc.App.Application.Exceptions;
using Discount.Grpc.App.Application.Interfaces;
using Discount.Grpc.Shared.Contracts;
using System.Net;

namespace Discount.Grpc.App.Application.Services;

public class DiscountApplicationService : IDiscountApplicationService
{
    private readonly IDiscountRepository _discountRepository;

    public DiscountApplicationService(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public async Task<CouponModel> CreateDiscountAsync(CouponModel discount)
    {
        await _discountRepository.CreateDiscountAsync(discount);

        return await GetDiscountAsync(discount.ProductName);
    }

    public async Task<IsSuccessModel> DeleteDiscountAsync(string productName)
    {
        var isDeleted = await _discountRepository.DeleteDiscountAsync(productName);
        if (isDeleted)
            return new IsSuccessModel { IsSuccess = true };

        throw new AppException(HttpStatusCode.NotFound, "Product not found.");
    }

    public async Task<CouponModel> GetDiscountAsync(string productName)
    {
        var dbDiscount = await _discountRepository.GetDiscountAsync(productName);
        if (dbDiscount is null)
            throw new AppException(HttpStatusCode.NotFound, "Discount not found.");

        return dbDiscount;
    }

    public async Task<CouponModel> UpdateDiscountAsync(CouponModel discount)
    {
        var isUpdated = await _discountRepository.UpdateDiscountAsync(discount);
        if (isUpdated)
            return await GetDiscountAsync(discount.ProductName);

        throw new AppException(HttpStatusCode.InternalServerError, "Operation fail.");
    }
}
