namespace EShop.Product.Core.Domain.ResponseModel;

public record ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int AvailableStock { get; set; }

    public string ProductTypeName { get; set; }

    public string ProductBrandName { get; set; }
}