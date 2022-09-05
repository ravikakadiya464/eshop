namespace EShop.Product.Core.Domain.RequestModel;

public record OrderRequest
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }
}