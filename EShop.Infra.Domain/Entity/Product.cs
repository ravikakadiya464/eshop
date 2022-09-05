namespace EShop.Infra.Domain.Entity;


public class Product
{
    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public decimal Price { get; private set; }

    public int AvailableStock { get; private set; }

    public int ProductTypeId { get; private set; }

    public int ProductBrandId { get; private set; }

    public virtual ProductType ProductType { get; private set; }

    public virtual ProductBrand ProductBrand { get; private set; }


    public Product(int id, string name, decimal price, int availableStock, int productTypeId, int productBrandId, string description = null)
    {
        Id = id;
        Name = name;
        Price = price;
        AvailableStock = availableStock;
        ProductTypeId = productTypeId;
        ProductBrandId = productBrandId;
        Description = description;
    }

    public Product(string name, decimal price, int availableStock, int productTypeId, int productBrandId, string description = null)
    {
        Name = name;
        Price = price;
        AvailableStock = availableStock;
        ProductTypeId = productTypeId;
        ProductBrandId = productBrandId;
        Description = description;
    }
}