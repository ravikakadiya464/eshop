using EShop.Common.Enums;

namespace EShop.Product.Core.Domain.ResponseModel;

public record OrderResponse
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public int Quantity { get; set; }

    public decimal BillAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public OrderStatus OrderStatus { get; set; }

    public virtual ProductResponse Product { get; set; }
}