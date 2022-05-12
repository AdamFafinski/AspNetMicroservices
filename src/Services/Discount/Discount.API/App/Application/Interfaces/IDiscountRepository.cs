using Discount.API.App.Domain.Entities;

namespace Discount.API.App.Application.Interfaces;

public interface IDiscountRepository
{
    Task<Coupon> GetDiscount(string productNam);
    Task<bool> CreateDiscount(Coupon coupon);
    Task<bool> UpdateDiscount(Coupon coupon);
    Task<bool> DeleteDiscount(string productName);
}
