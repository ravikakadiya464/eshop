namespace EShop.Core.Domain.RequestModel;

public record ShippingRequest
{
    public int OrderId { get; set; }
}