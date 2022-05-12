using ProtoBuf.Grpc;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Discount.Grpc.Shared.Contracts;

[DataContract]
public class GetDiscountRequest
{
    [DataMember(Order = 1)]
    public string ProductName { get; set; }
}

[DataContract]
public class CreateDiscountRequest
{
    [DataMember(Order = 1)]
    public CouponModel Coupon { get; set; }
}

[DataContract]
public class UpdateDiscountRequest
{
    [DataMember(Order = 1)]
    public CouponModel Coupon { get; set; }
}

[DataContract]
public class DeleteDiscountRequest
{
    [DataMember(Order = 1)]
    public string ProductName { get; set; }
}

[DataContract]
public class CouponModel
{
    [DataMember(Order = 1)]
    public int Id { get; set; }

    [DataMember(Order = 2)]
    public string ProductName { get; set; }

    [DataMember(Order = 3)]
    public string Description { get; set; }

    [DataMember(Order = 4)]
    public int Amount { get; set; }
}

[DataContract]
public class IsSuccessModel
{
    [DataMember(Order = 1)]
    public bool IsSuccess { get; set; }
}

[ServiceContract]
public interface IDiscountService
{
    [OperationContract]
    Task<CouponModel> GetDiscountAsync(GetDiscountRequest discountRequest, CallContext context = default);

    [OperationContract]
    Task<CouponModel> CreateDiscountAsync(CreateDiscountRequest createDiscountRequest, CallContext context = default);

    [OperationContract]
    Task<CouponModel> UpdateDiscountAsync(UpdateDiscountRequest updateDiscountRequest, CallContext context = default);

    [OperationContract]
    Task<IsSuccessModel> DeleteDiscountAsync(DeleteDiscountRequest deleteDiscountRequest, CallContext context = default);
}