using Basket.API.App.Application.Interfaces;
using Discount.Grpc.Shared.Contracts;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace Basket.API.App.Infrastructure.Services;

//https://docs.microsoft.com/en-us/aspnet/core/grpc/code-first?view=aspnetcore-6.0

public class DiscountGrpcService : IDiscountGrpcService
{
    private readonly string _connectionString;

    public DiscountGrpcService(IConfiguration configuration)
    {
        _connectionString = configuration.GetValue<string>("DiscountGrpc:ConnectionString");
    }

    public async Task<CouponModel> GetDiscountAsync(GetDiscountRequest getDiscountRequest)
    {
        using var channel = GrpcChannel.ForAddress(_connectionString);
        var client = channel.CreateGrpcService<IDiscountService>();

        return await client.GetDiscountAsync(getDiscountRequest);
    }
}
