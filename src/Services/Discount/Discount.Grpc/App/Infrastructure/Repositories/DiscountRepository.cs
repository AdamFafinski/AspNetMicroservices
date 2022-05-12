using Dapper;
using Discount.Grpc.App.Application.Interfaces;
using Discount.Grpc.Shared.Contracts;
using Npgsql;

namespace Discount.Grpc.App.Infrastructure.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly string _connectionString;

    public DiscountRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("DatabaseSettings:ConnectionString");
    }

    public async Task<CouponModel> GetDiscountAsync(string productName)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var dbCoupon =  await connection.QueryFirstOrDefaultAsync<CouponModel>
            ("SELECT * FROM Coupon WHERE ProductName = @productName", 
            new { productName });

        if (dbCoupon is null)
            return new CouponModel { ProductName = "NO DISCOUNT", Amount = 0, Description = "NO DISCOUNT DESCRIPTION" };

        return dbCoupon;
    }

    public async Task<bool> CreateDiscountAsync(CouponModel coupon)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync
            ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)", 
            new { coupon.ProductName, coupon.Description, coupon.Amount });

        return affected != 0;
    }

    public async Task<bool> UpdateDiscountAsync(CouponModel coupon)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync
            ("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
            new { coupon.ProductName, coupon.Description, coupon.Amount, coupon.Id });

        return affected != 0;
    }

    public async Task<bool> DeleteDiscountAsync(string productName)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var affected = await connection.ExecuteAsync
            ("DELETE FROM Coupon WHERE ProductName = @productName",
            new { productName });

        return affected != 0;
    }
}
