using EShop.Common.Enums;

namespace EShop.Infra.Domain.Entity;


public class Order
{
    public int Id { get; private set; }

    public int ProductId { get; private set; }

    public Guid UserId { get; private set; }

    public int Quantity { get; private set; }

    public decimal BillAmount { get; private set; }

    public DateTime OrderDate { get; private set; }

    public OrderStatus OrderStatus { get; private set; }

    public virtual Product Product { get; private set; }

    public Order(int productId, Guid userId, int quantity, decimal billAmount)
    {
        ProductId = productId;
        UserId = userId;
        Quantity = quantity;
        BillAmount = billAmount;
        OrderDate = DateTime.UtcNow;
        OrderStatus = OrderStatus.AwaitingShipment;
    }

    public Order UpdateStatus(OrderStatus status)
    {
        OrderStatus = status;
        return this;
    }
}